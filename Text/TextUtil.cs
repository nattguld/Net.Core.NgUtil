using NgUtil.Debugging.Contracts;
using NgUtil.Maths;
using NgUtil.Systems;
using NgUtil.Text.Clipboards;
using NgUtil.Text.Clipboards.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NgUtil.Text {
    public static class TextUtil {

        public const string UrlRegex = "((https?|ftp|gopher|telnet|file):((//)|(\\\\))+[\\w\\d:#@%/;$()~_?\\+-=\\\\\\.&]*[-a-zA-Z0-9+&@#/%=~_|])";


        public static string ZerofyInteger(int value) {
            return value < 10 ? ("0" + value) : StringLocale.ToString(value);
        }

        public static string GetAsNonNull(string input) {
            return string.IsNullOrEmpty(input) ? "" : input;
        }

        public static List<string> ExtractUrls(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            List<string> urls = new List<string>();

            Regex regex = new Regex(UrlRegex, RegexOptions.IgnoreCase);
            MatchCollection results = regex.Matches(input);
            
            foreach (Match match in results) {
                urls.Add(match.Value);
            }
            return urls;
        }

        public static string ExtractDigits(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            Regex regex = new Regex("\\d+");
            MatchCollection results = regex.Matches(input);

            StringBuilder digits = new StringBuilder();

            foreach (Match match in results) {
                digits.Append(match.Value);
            }
            return digits.ToString();
        }

        public static void CopyToClipboardAsync(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));
            Task.Run(() => CopyToClipboard(input));
        }

        public static void CopyToClipboard(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            IClipboard clipboard;

            if (SystemUtil.IsWindows()) {
                clipboard = new WindowsClipboard();

            } else if (SystemUtil.IsOSX()) {
                clipboard = new OSXClipboard();

            } else if (SystemUtil.IsLinux()) {
                clipboard = new LinuxClipboard();

            } else {
                throw new Exception("Unable to copy to clipboard, OS not detected");
            }
            clipboard.CopyToClipboard(input);
        }

        public static string Capitalize(string input) {
            if (string.IsNullOrEmpty(input)) {
                return "";
            }
            string prepared = StringLocale.ToLower(input);
            return StringLocale.ToUpper(prepared.Substring(0, 1)) + prepared.Substring(1);
        }

        public static string Capitalize(string input, string delimiter) {
            if (string.IsNullOrEmpty(input)) {
                return "";
            }
            EmptyParamContract.Validate(!string.IsNullOrEmpty(delimiter));

            string[] parts = input.Split(delimiter);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < parts.Length; i++) {
                sb.Append(Capitalize(parts[i]));

                if (i < (parts.Length - 1)) {
                    sb.Append(delimiter);
                }
            }
            return sb.ToString();
        }

        public static string RandomString(int minSize, int maxSize, params ETextSeed[] seeds) {
            if (seeds == null || seeds.Length == 0) {
                throw new Exception("Invalid string generator arguments.");
            }
            List<string> characters = new List<string>();
            int size = minSize + (maxSize == minSize ? 0 : MathUtil.Random(maxSize - minSize));

            while (characters.Count < size) {
                string[] chars = seeds[MathUtil.Random(seeds.Length)].GetCharacters();

                if (characters.Count >= (size - seeds.Length)) {
                    int seedIndex = size - characters.Count;
                    ETextSeed seed = seeds[seedIndex - 1];
                    bool missingSeed = true;

                    foreach (string s in seed.GetCharacters()) {
                        if (characters.Contains(s)) {
                            missingSeed = false;
                            break;
                        }
                    }
                    if (missingSeed) {
                        chars = seed.GetCharacters();
                    }
                }
                characters.Add(chars[MathUtil.Random(chars.Length)]);
            }
            StringBuilder sb = new StringBuilder();

            foreach (string s in characters) {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public static string GeneratePassword() {
            return RandomString(8, 16, ETextSeed.Digits, ETextSeed.Lowercase, ETextSeed.Uppercase);
        }

        public static string GenerateComplexPassword() {
            return RandomString(8, 16, ETextSeed.Digits, ETextSeed.Lowercase, ETextSeed.Uppercase, ETextSeed.Symbols);
        }

        public static string GenerateRandomNumber() {
            return GenerateRandomNumber(20, 25);
        }

        public static string GenerateRandomNumber(int minSize, int maxSize) {
            return RandomString(minSize, maxSize, ETextSeed.Digits);
        }

        public static string GenerateFakeEmail() {
            return GenerateFakeEmail("@gmail.com");
        }

        public static string GenerateFakeEmail(string domain) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(domain));

            if (!domain.StartsWith("@", StringComparison.Ordinal)) {
                domain = "@" + domain;
            }
            return TextUtil.RandomString(8, 16, ETextSeed.Lowercase) + MathUtil.Random(999) + domain;
        }

        public static string Spintax(string input) {
            if (string.IsNullOrEmpty(input)) {
                return "";
            }
            if (!input.Contains("{", StringComparison.Ordinal) && !input.Contains("}", StringComparison.Ordinal)) {
                return input;
            }
            Regex regex = new Regex("\\{[^{}]*\\}");
            Random rnd = new Random();

            while (regex.IsMatch(input)) {
                Match match = regex.Match(input);
                string parts = input.Substring(match.Index, match.Length);
                string[] subParts = parts.Split("\\|", -1);
                input = input.Substring(0, match.Index) + subParts[rnd.Next(subParts.Length)] + input.Substring(match.Index + match.Length);
            }
            /*
            while (matcher.find()) {
                string parts = input.substring(matcher.start() + 1, matcher.end() - 1);
                string[] subParts = parts.split("\\|", -1);
                input = input.substring(0, matcher.start()) + subParts[rnd.nextInt(subParts.length)].toString()
                    + input.substring(matcher.start() + matcher.group().length());
                matcher = pattern.matcher(input);
            }*/
            return input;
        }

        public static bool IsLetters(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            foreach (char c in input.ToCharArray()) {
                if (!char.IsLetter(c)) {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDigits(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));

            foreach (char c in input.ToCharArray()) {
                if (!char.IsDigit(c)) {
                    return false;
                }
            }
            return true;
        }

    }
}
