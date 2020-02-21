using NgUtil.Debugging.Contracts;
using NgUtil.Maths.Ranges.Impl;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace NgUtil.Files {
    public static class FileHandler {


        public static FileLink CreateFile(string filePath, bool overwrite = false) {
            EmptyParamContract.Validate(filePath);
            return CreateFile(new FileLink(filePath), overwrite);
        }

        public static FileLink CreateFile(FileLink fileLink, bool overwrite = false) {
            EmptyParamContract.Validate(fileLink);

            if (!overwrite && File.Exists(fileLink.Path)) {
                return fileLink;
            }
            File.Create(fileLink.Path).Dispose();
            return fileLink;
        }

        public static FileLink CreateDirectory(string directoryPath, bool overwrite = false) {
            EmptyParamContract.Validate(directoryPath);
            return CreateDirectory(new FileLink(directoryPath), overwrite);
        }

        public static FileLink CreateDirectory(FileLink dirLink, bool overwrite = false) {
            EmptyParamContract.Validate(dirLink);

            if (!overwrite && Directory.Exists(dirLink.Path)) {
                return dirLink;
            }
            Directory.CreateDirectory(dirLink.Path);
            return dirLink;
        }

        public static void Delete(string path, bool recursive = false) {
            EmptyParamContract.Validate(path);

            Delete(new FileLink(path), recursive);
        }

        public static void Delete(FileLink fileLink, bool recursive = false) {
            EmptyParamContract.Validate(fileLink);

            if (fileLink.IsFile()) {
                File.Delete(fileLink.Path);
                return;
            }
            Directory.Delete(fileLink.Path, recursive);
        }

        public static void Rename(string sourcePath, string destinationPath, bool overwrite = true) {
            Move(sourcePath, destinationPath, overwrite);
        }

        public static void Rename(FileLink source, FileLink destination, bool overwrite = true) {
            Move(source, destination, overwrite);
        }

        public static void Move(string sourcePath, string destinationPath, bool overwrite = true) {
            EmptyParamContract.Validate(sourcePath);
            EmptyParamContract.Validate(destinationPath);

            Move(new FileLink(sourcePath), new FileLink(destinationPath), overwrite);
        }

        public static void Move(FileLink source, FileLink destination, bool overwrite = true) {
            EmptyParamContract.Validate(source != null && destination != null && source.Exists());

            if (source.IsFile()) {
                File.Move(source.Path, destination.Path, overwrite);
                return;
            }
            Directory.Move(source.Path, destination.Path);
        }

        public static void Copy(FileLink source, FileLink destination, bool overwrite = true) {
            EmptyParamContract.Validate(source != null && destination != null && source.Exists());

            if (source.IsFile()) {
                File.Copy(source.Path, destination.Path, overwrite);
                return;
            }
            foreach (string filePath in Directory.GetFiles(source.Path)) {
                string fileName = Path.GetFileName(filePath);
                FileLink fileLink = new FileLink(filePath);
                FileLink copyLink = new FileLink(Path.Combine(destination.Path, fileName));

                if (Directory.Exists(filePath)) {
                    CreateDirectory(copyLink);
                }
                Copy(fileLink, copyLink, overwrite);
            }
        }

        public static void Copy(string sourcePath, string destinationPath, bool overwrite = true) {
            EmptyParamContract.Validate(sourcePath);
            EmptyParamContract.Validate(destinationPath);

            Copy(new FileLink(sourcePath), new FileLink(destinationPath), overwrite);
        }

        public static string GetSafeFileName(string fileName) {
            EmptyParamContract.Validate(fileName);

            string safeName = fileName.Replace(" ", "_", StringComparison.Ordinal)
                .Replace(":", ".", StringComparison.Ordinal);
            Regex.Replace(safeName, "[\\W&&[^-]]+", ".");
            return safeName;
        }

        public static FileLink AddRandomBytes(FileLink input, FileLink output) {
            EmptyParamContract.Validate(input != null && output != null && input.IsFile() && input.Exists());

            byte[] original = File.ReadAllBytes(input.Path);
            byte add = new ByteRange(byte.MinValue, byte.MaxValue).GetRandom();
            byte[] modified = new byte[original.Length + 1];

            for (int i = 0; i < original.Length; i++) {
                modified[i] = original[i];
            }
            modified[modified.Length - 1] = add;
            File.WriteAllBytes(output.Path, modified);
            return output;
        }

        public static FileLink AddRandomBytes(string inputPath, string outputPath) {
            EmptyParamContract.Validate(inputPath);
            EmptyParamContract.Validate(outputPath);

            return AddRandomBytes(new FileLink(inputPath), new FileLink(outputPath));
        }

    }
}
