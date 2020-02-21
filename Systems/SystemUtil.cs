using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace NgUtil.Systems {
    public static class SystemUtil {


		public static NumberFormatInfo GetNumberFormatInfo() {
			return NumberFormatInfo.CurrentInfo;
		}

		public static DateTimeFormatInfo GetDateTimeFormatInfo() {
			return DateTimeFormatInfo.CurrentInfo;
		}

		public static CultureInfo GetCultureInfo() {
			return CultureInfo.CurrentCulture;
		}
	
		public static string GetHomeDir() {
			return Environment.GetEnvironmentVariable("HOME");
		}

		public static string GetNetCoreVersion() {
			return Environment.Version.ToString();
		}


		public static bool IsWindows() {
			return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
		}


		public static bool IsOSX() {
			return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
		}


		public static bool IsLinux() {
			return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
		}

	
		public static bool IsUnix() {
			return IsOSX() || IsLinux();
		}


		public static int GetCPUCores() {
			return Environment.ProcessorCount;
		}

		public static string GetUser() {
			return Environment.UserName;
		}

	
		public static long GetUsedRAM() {
			return Process.GetCurrentProcess().WorkingSet64;
		}

	}

}
