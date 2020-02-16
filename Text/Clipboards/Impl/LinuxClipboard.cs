using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace NgUtil.Text.Clipboards.Impl {
    public sealed class LinuxClipboard : IClipboard  {


        public void CopyToClipboard(string input) {
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, input);

            try {
                ExecuteBash($"cat {tempFileName} | xclip");

            } finally {
                File.Delete(tempFileName);
            }
        }

        private static string ExecuteBash(string command) {
            StringBuilder errorBuilder = new StringBuilder();
            StringBuilder outputBuilder = new StringBuilder();
            string arguments = $"-c \"{command}\"";

            using (Process process = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "bash",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                }
            }) {
                process.Start();
                process.OutputDataReceived += (sender, args) => { outputBuilder.AppendLine(args.Data); };
                process.BeginOutputReadLine();
                process.ErrorDataReceived += (sender, args) => { errorBuilder.AppendLine(args.Data); };
                process.BeginErrorReadLine();

                if (!process.WaitForExit(500)) {
                    string timeoutError = $@"Process timed out. Command line: bash {arguments}. Output: {outputBuilder} Error: {errorBuilder}";
                    throw new Exception(timeoutError);
                }
                if (process.ExitCode == 0) {
                    return outputBuilder.ToString();
                }
                string error = $@"Could not execute process. Command line: bash {arguments}. Output: {outputBuilder} Error: {errorBuilder}";
                throw new Exception(error);
            }
        }

    }
}
