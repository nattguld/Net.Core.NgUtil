using NgUtil.Debugging.Contracts;
using NgUtil.Text;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NgUtil {
    public static class Misc {

        public static void OpenLink(string link) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(link));

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                Process.Start(new ProcessStartInfo(link) { UseShellExecute = true }); // Works ok on windows
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                Process.Start("xdg-open", link);  // Works ok on linux
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                Process.Start("open", link); // Not tested
            } else {
                throw new Exception("Failed to open link: " + link);
            }
        }

        public static void Sleep(int ms) {
            Thread.Sleep(ms);
        }
        
        public static string RandomMACAddress() {
            Random rand = new Random();
            byte[] macAddr = new byte[6];

            rand.NextBytes(macAddr);
            macAddr[0] = (byte)(macAddr[0] & (byte)254);  //zeroing last 2 bytes to make it unicast and locally adminstrated

            StringBuilder sb = new StringBuilder(18);

            foreach (byte b in macAddr) {
                if (sb.Length > 0) {
                    sb.Append(":");
                }
                sb.Append(string.Format("%02x", b));
            }
            return StringLocale.ToUpper(sb.ToString());
        }

    }
}
