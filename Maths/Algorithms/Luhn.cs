using NgUtil.Debugging.Contracts;

namespace NgUtil.Maths.Algorithms {
    public static class Luhn {

        public static int GenerateChecksumDigit(string number) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(number));

            char sum = default;

            bool alt = true;
            char[] digits = number.ToCharArray();

            for (int i = digits.Length - 1; i >= 0; i--) {
                int curDigit = (digits[i] - 48);

                if (alt) {
                    curDigit *= 2;

                    if (curDigit > 9) {
                        curDigit -= 9;
                    }
                }
                sum += (char)curDigit;
                alt = !alt;
            }
            if ((sum % 10) == 0) {
                return 0;
            }
            return (10 - (sum % 10));
        }

        public static bool IsValid(string number) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(number));

            int sum = 0;
            bool alternate = false;

            for (int i = number.Length - 1; i >= 0; i--) {
                int n = MathUtil.ParseInt(number.Substring(i, i + 1));

                if (alternate) {
                    n *= 2;

                    if (n > 9) {
                        n = (n % 10) + 1;
                    }
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

    }
}
