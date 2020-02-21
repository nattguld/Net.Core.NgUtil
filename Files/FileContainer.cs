using NgUtil.Generics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace NgUtil.Files {
    public class FileContainer : GenericQueueContainer<FileLink> {

        public FileLink FileLink { get; }

        public bool IsRecursive { get; }


        public FileContainer(string path) : this(new FileLink(path)) { }

        public FileContainer(FileLink fileLink) {
            FileLink = fileLink;
        }

        public override FileLink NextElement() {
            if (IsContainerEmpty()) {
                LoadFiles();
            }
            return base.NextElement();
        }

        private void LoadFiles() {
            if (!FileLink.Exists()) {
                Debug.WriteLine(FileLink.Path + " does not exist");
                return;
            }
            if (FileLink.IsFile()) {
                AddElement(FileLink);
                return;
            }
            foreach (string filePath in Directory.GetFiles(FileLink.Path)) {
                if (Directory.Exists(filePath)) {
                    continue;
                }
                AddElement(new FileLink(filePath));
            }
        }

    }
}
