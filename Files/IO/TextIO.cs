using NgUtil.Debugging.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NgUtil.Files.IO {
    public static class TextIO {


        public static string GetContent(string path) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(path));
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public static string[] GetLinesAsArray(string path) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(path));
            return File.ReadAllLines(path, Encoding.UTF8);
        }

        public static List<string> GetLines(string path) {
            List<string> lines = new List<string>();

            foreach (string line in GetLinesAsArray(path)) {
                lines.Add(line);
            }
            return lines;
        }

        public static FileInfo Write(string path, string content, bool append = true) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(content));

            if (append) {
                File.AppendAllText(path, content, Encoding.UTF8);
            } else {
                File.WriteAllText(path, content, Encoding.UTF8);
            }
            return new FileInfo(path);
        }

        public static void WriteAsync(string path, string content, bool append = true) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(content));

            if (append) {
                File.AppendAllTextAsync(path, content, Encoding.UTF8);
            } else {
                File.WriteAllTextAsync(path, content, Encoding.UTF8);
            }
        }

        public static FileInfo WriteLines(string path, List<string> lines, bool append = true) {
            EmptyParamContract.Validate(lines != null);
            return WriteLines(path, lines.ToArray(), append);
        }

        public static FileInfo WriteLines(string path, string[] lines, bool append = true) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(path) && lines != null);

            if (append) {
                File.AppendAllLines(path, lines, Encoding.UTF8);
            } else {
                File.WriteAllLines(path, lines, Encoding.UTF8);
            }
            return new FileInfo(path);
        }

        public static void WriteLinesAsync(string path, List<string> lines, bool append = true) {
            EmptyParamContract.Validate(lines != null);

            WriteLinesAsync(path, lines.ToArray(), append);
        }

        public static void WriteLinesAsync(string path, string[] lines, bool append = true) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(path) && lines != null);

            if (append) {
                File.AppendAllLinesAsync(path, lines, Encoding.UTF8);
            } else {
                File.WriteAllLinesAsync(path, lines, Encoding.UTF8);
            }
        }

    }
}
