using NgUtil.Debugging.Contracts;
using System;
using System.Runtime.InteropServices;

namespace NgUtil.Text.Clipboards.Impl {
    public sealed class OSXClipboard : IClipboard {

        private const string NSPasteboardTypeString = "public.utf8-plain-text";


        public void CopyToClipboard(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            IntPtr nsString = NativeMethods.objc_getClass("NSString");
            IntPtr str = default;
            IntPtr dataType = default;

            try {
                str = NativeMethods.objc_msgSend(NativeMethods.objc_msgSend(nsString, NativeMethods.sel_registerName("alloc"))
                    , NativeMethods.sel_registerName("initWithUTF8String:"), input);
                dataType = NativeMethods.objc_msgSend(NativeMethods.objc_msgSend(nsString, NativeMethods.sel_registerName("alloc"))
                    , NativeMethods.sel_registerName("initWithUTF8String:"), NSPasteboardTypeString);

                IntPtr nsPasteboard = NativeMethods.objc_getClass("NSPasteboard");
                IntPtr generalPasteboard = NativeMethods.objc_msgSend(nsPasteboard, NativeMethods.sel_registerName("generalPasteboard"));

                NativeMethods.objc_msgSend(generalPasteboard, NativeMethods.sel_registerName("clearContents"));
                NativeMethods.objc_msgSend(generalPasteboard, NativeMethods.sel_registerName("setString:forType:"), str, dataType);

            } finally {
                if (str != default) {
                    NativeMethods.objc_msgSend(str, NativeMethods.sel_registerName("release"));
                }
                if (dataType != default) {
                    NativeMethods.objc_msgSend(dataType, NativeMethods.sel_registerName("release"));
                }
            }
        }

        internal static class NativeMethods {

            [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit", CharSet = CharSet.Unicode)]
            internal static extern IntPtr objc_getClass(string className);

            [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit", CharSet = CharSet.Unicode)]
            internal static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector);

            [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit", CharSet = CharSet.Unicode)]
            internal static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, string arg1);

            [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit", CharSet = CharSet.Unicode)]
            internal static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

            [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit", CharSet = CharSet.Unicode)]
            internal static extern IntPtr sel_registerName(string selectorName);

        }

    }
}
