using System;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;

namespace NgUtil.System {
    public static class SystemUtil {

		/**
		 * Retrieves the default home directory.
		 * 
		 * @return The home directory.
		 */
		public static string GetHomeDir() {
			return Environment.GetEnvironmentVariable("HOME");
		}

		/**
		 * Retrieves the version of the net core runtime being ran.
		 * 
		 * @return The version.
		 */
		public static string GetNetCoreVersion() {
			return Environment.Version.ToString();
		}

		/**
		 * Retrieves whether the OS is windows based or not.
		 * 
		 * @return The result.
		 */
		public static bool IsWindows() {
			return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
		}

		/**
		 * Retrieves whether the OS is osx based or not.
		 * 
		 * @return The result.
		 */
		public static bool IsOSX() {
			return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
		}

		/**
		 * Retrieves whether the OS is linux based or not.
		 * 
		 * @return The result.
		 */
		public static bool IsLinux() {
			return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
		}

		/**
		 * Retrieves whether the OS is unix based or not.
		 * 
		 * @return The result.
		 */
		public static bool IsUnix() {
			return IsOSX() || IsLinux();
		}

		/**
		 * Retrieves the amount of CPU cores available.
		 * 
		 * @return The cores.
		 */
		public static int GetCPUCores() {
			return Environment.ProcessorCount;
		}

		public static string GetUser() {
			return Environment.UserName;
		}

		/**
		 * Retrieves the amount of RAM in use.
		 * 
		 * @return The amount of RAM in use.
		 */
		public static long GetUsedRAM() {
			return Process.GetCurrentProcess().WorkingSet64;
		}

	}

}
