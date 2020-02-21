using NgUtil.Debugging.Contracts;
using NgUtil.Maths;
using NgUtil.Text;
using System;
using System.IO;
using System.Text;

namespace NgUtil {
    public static class Converter {

        public static string ToBase64(FileInfo f) {
            EmptyParamContract.Validate(f != null);
            return ToBase64(File.ReadAllBytes(f.FullName));
        }

        public static string ToBase64(byte[] bytes) {
            EmptyParamContract.Validate(bytes != null);
            return Convert.ToBase64String(bytes);
        }

        public static FileInfo Base64ToFile(string savePath, string base64) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(savePath) && !string.IsNullOrEmpty(base64));

            byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(savePath, bytes);
            return new FileInfo(savePath);
        }

        public static string ToBase64(string input) {
            return ToBase64(input, Encoding.UTF8);
        }

        public static string ToBase64(string input, Encoding encoding) {
            EmptyParamContract.Validate(input);
            EmptyParamContract.Validate(encoding);
            return ToBase64(encoding.GetBytes(input));
        }

        public static string FromBase64(string base64) {
            return FromBase64(base64, Encoding.UTF8);
        }

        public static string FromBase64(string base64, Encoding encoding) {
            byte[] bytes = Convert.FromBase64String(base64);
            return encoding.GetString(bytes);
        }

        public static string BytesToHex(byte[] bytes) {
            EmptyParamContract.Validate(bytes != null);
            return BytesToHexString(bytes).Replace("-", string.Empty, StringComparison.Ordinal);
        }

        public static string BytesToHexString(byte[] bytes) {
            EmptyParamContract.Validate(bytes != null);
            return BitConverter.ToString(bytes);
        }

        public static string BytesToHexAlt(byte[] bytes) {
            EmptyParamContract.Validate(bytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++) {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static int FormatIntegerText(string text) {
            return (int)FormatNumberText(text);
        }
        public static double FormatDoubleText(string text) {
            return (double)FormatNumberText(text);
        }

        public static IConvertible FormatNumberText(string text) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(text));

            string simplify = StringLocale.ToLower(text.Trim());

            if (string.IsNullOrEmpty(simplify)) {
                return 0;
            }
            string[] parts = simplify.Split(" ");

            foreach (string part in parts) {
                if (part.EndsWith("k", StringComparison.OrdinalIgnoreCase) 
                    || part.EndsWith("m", StringComparison.OrdinalIgnoreCase) 
                    || part.EndsWith("b", StringComparison.OrdinalIgnoreCase)
                    || part.Contains(".", StringComparison.Ordinal) 
                    || part.Contains(",", StringComparison.Ordinal)) {
                    simplify = part.Trim();
                    break;
                }
            }
            int multiplier = 1;

            if (simplify.Contains("k", StringComparison.OrdinalIgnoreCase) 
                || simplify.Contains("m", StringComparison.OrdinalIgnoreCase) 
                || simplify.Contains("b", StringComparison.OrdinalIgnoreCase)) {
                if (simplify.Contains("k", StringComparison.OrdinalIgnoreCase)) {
                    simplify = simplify.Replace("k", "", StringComparison.OrdinalIgnoreCase);
                    multiplier = 1000;

                } else if (simplify.Contains("m", StringComparison.OrdinalIgnoreCase)) {
                    simplify = simplify.Replace( "m", "", StringComparison.OrdinalIgnoreCase);
                    multiplier = 1000000;

                } else if (simplify.Contains("b", StringComparison.OrdinalIgnoreCase)) {
                    simplify = simplify.Replace("b", "", StringComparison.OrdinalIgnoreCase);
                    multiplier = 1000000000;
                }
            }
            if (simplify.Contains(",", StringComparison.Ordinal)) {
                simplify = simplify.Replace(",", "", StringComparison.Ordinal);
            }
            parts = simplify.Split(" ");

            foreach (string part in parts) {
                if (!MathUtil.IsInteger(part) && !MathUtil.IsDouble(part)) {
                    continue;
                }
                simplify = part.Trim();
                break;
            }
            return (simplify.Contains(".", StringComparison.OrdinalIgnoreCase) 
                ? MathUtil.ParseDouble(simplify) : MathUtil.ParseInt(simplify)) * multiplier;
        }

    } 
}
