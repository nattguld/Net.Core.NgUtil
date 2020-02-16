using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NgUtil.Text.Clipboards.Impl {
    public sealed class WindowsClipboard : IClipboard {

        private const uint cfUnicodeText = 13;


        public void CopyToClipboard(string input) {
            if (!WaitForClipboard()) {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            EmptyClipboard();

            IntPtr hGlobal = default;

            try {
                var bytes = (input.Length + 1) * 2;
                hGlobal = Marshal.AllocHGlobal(bytes);

                if (hGlobal == default) {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                var target = GlobalLock(hGlobal);

                if (target == default) {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                try {
                    Marshal.Copy(input.ToCharArray(), 0, target, input.Length);
                } finally {
                    GlobalUnlock(target);
                }
                if (SetClipboardData(cfUnicodeText, hGlobal) == default) {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                hGlobal = default;

            } finally {
                if (hGlobal != default) {
                    Marshal.FreeHGlobal(hGlobal);
                }
                CloseClipboard();
            }
        }

        private static bool WaitForClipboard() {
            int timeout = 1000;

            while (timeout > 0) {
                if (OpenClipboard(default)) {
                    return true;
                }
                timeout -= 100;
                Misc.Sleep(100);
            }
            return false;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);

        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();

    }
}
