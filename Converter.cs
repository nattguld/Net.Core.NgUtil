using NgUtil.Maths;
using System;
using System.IO;

namespace NgUtil {
    public static class Converter {

        public static string ToBase64(FileInfo f) {
            return ToBase64(File.ReadAllBytes(f.FullName));
        }

        public static string ToBase64(byte[] bytes) {
            return Convert.ToBase64String(bytes);
        }

        public static FileInfo Base64ToFile(string savePath, string base64) {
            byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(savePath, bytes);
            return new FileInfo(savePath);
        }

        public static string BytesToHex(byte[] bytes) {
            return BytesToHexString(bytes).Replace("-", string.Empty);
        }

        public static string BytesToHexString(byte[] bytes) {
            return BitConverter.ToString(bytes);
        }

        public static int FormatIntegerText(string text) {
            return (int)FormatNumberText(text);
        }
        public static double FormatDoubleText(string text) {
            return (double)FormatNumberText(text);
        }

        public static IConvertible FormatNumberText(string text) {
            string simplify = text.Trim().ToLower();

            if (string.IsNullOrEmpty(simplify)) {
                return 0;
            }
            string[] parts = simplify.Split(" ");

            foreach (string part in parts) {
                if (part.EndsWith("k") || part.EndsWith("m") || part.EndsWith("b")
                    || part.Contains(".") || part.Contains(",")) {
                    simplify = part.Trim();
                    break;
                }
            }
            int multiplier = 1;

            if (simplify.Contains("k") || simplify.Contains("m") || simplify.Contains("b")) {
                if (simplify.Contains("k")) {
                    simplify = simplify.Replace("k", "");
                    multiplier = 1000;

                } else if (simplify.Contains("m")) {
                    simplify = simplify.Replace("m", "");
                    multiplier = 1000000;

                } else if (simplify.Contains("b")) {
                    simplify = simplify.Replace("b", "");
                    multiplier = 1000000000;
                }
            }
            if (simplify.Contains(",")) {
                simplify = simplify.Replace(",", "");
            }
            parts = simplify.Split(" ");

            foreach (string part in parts) {
                if (!MathUtil.IsInteger(part) && !MathUtil.IsDouble(part)) {
                    continue;
                }
                simplify = part.Trim();
                break;
            }
            return (simplify.Contains(".") ? double.Parse(simplify) : int.Parse(simplify)) * multiplier;
        }

    } 
}
