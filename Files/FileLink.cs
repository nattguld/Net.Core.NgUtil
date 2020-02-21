using System;
using System.IO;

namespace NgUtil.Files {
    public sealed class FileLink {

        public string Path { get; }

        private FileSystemInfo info;


        public FileLink(string path) {
            Path = path;
        }

        public bool Exists() {
            return File.Exists(Path) || Directory.Exists(Path);
        }

        public bool IsDirectory() {
            if (!Exists()) {
                throw new NullReferenceException();
            }
            return Directory.Exists(Path);
        }

        public bool IsFile() {
            if (!Exists()) {
                throw new NullReferenceException();
            }
            return File.Exists(Path);
        }

        public FileSystemInfo GetInfo() {
            if (info is null) {
                info = IsFile() ? new FileInfo(Path) : (FileSystemInfo)new DirectoryInfo(Path);
            }
            return info;
        }

    }

}
