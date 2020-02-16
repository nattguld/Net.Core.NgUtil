using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NgUtil.Text.Clipboards.Impl {
    public sealed class OSXClipboard : IClipboard {

        private const string NSPasteboardTypeString = "public.utf8-plain-text";


        public void CopyToClipboard(string input) {
            IntPtr nsString = objc_getClass("NSString");
            IntPtr str = default;
            IntPtr dataType = default;

            try {
                str = objc_msgSend(objc_msgSend(nsString, sel_registerName("alloc")), sel_registerName("initWithUTF8String:"), input);
                dataType = objc_msgSend(objc_msgSend(nsString, sel_registerName("alloc")), sel_registerName("initWithUTF8String:"), NSPasteboardTypeString);

                IntPtr nsPasteboard = objc_getClass("NSPasteboard");
                IntPtr generalPasteboard = objc_msgSend(nsPasteboard, sel_registerName("generalPasteboard"));

                objc_msgSend(generalPasteboard, sel_registerName("clearContents"));
                objc_msgSend(generalPasteboard, sel_registerName("setString:forType:"), str, dataType);

            } finally {
                if (str != default) {
                    objc_msgSend(str, sel_registerName("release"));
                }
                if (dataType != default) {
                    objc_msgSend(dataType, sel_registerName("release"));
                }
            }
        }

        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern IntPtr objc_getClass(string className);

        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, string arg1);

        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern IntPtr sel_registerName(string selectorName);

    }
}
