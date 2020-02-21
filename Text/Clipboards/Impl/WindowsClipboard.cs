using NgUtil.Debugging.Contracts;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NgUtil.Text.Clipboards.Impl {
    public sealed class WindowsClipboard : IClipboard {

        private const uint cfUnicodeText = 13;


        public void CopyToClipboard(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            if (!WaitForClipboard()) {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            NativeMethods.EmptyClipboard();

            IntPtr hGlobal = default;

            try {
                var bytes = (input.Length + 1) * 2;
                hGlobal = Marshal.AllocHGlobal(bytes);

                if (hGlobal == default) {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                var target = NativeMethods.GlobalLock(hGlobal);

                if (target == default) {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                try {
                    Marshal.Copy(input.ToCharArray(), 0, target, input.Length);
                } finally {
                    NativeMethods.GlobalUnlock(target);
                }
                if (NativeMethods.SetClipboardData(cfUnicodeText, hGlobal) == default) {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                hGlobal = default;

            } finally {
                if (hGlobal != default) {
                    Marshal.FreeHGlobal(hGlobal);
                }
                NativeMethods.CloseClipboard();
            }
        }

        private static bool WaitForClipboard() {
            int timeout = 1000;

            while (timeout > 0) {
                if (NativeMethods.OpenClipboard(default)) {
                    return true;
                }
                timeout -= 100;
                Misc.Sleep(100);
            }
            return false;
        }

        internal static class NativeMethods {

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr GlobalLock(IntPtr hMem);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GlobalUnlock(IntPtr hMem);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseClipboard();

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);

            [DllImport("user32.dll")]
            internal static extern bool EmptyClipboard();

        }

    }
}
