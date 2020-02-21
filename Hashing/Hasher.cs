using NgUtil.Debugging.Contracts;
using System.Security.Cryptography;
using System.Text;
using NgUtil.Files;
using System.IO;
using System.Threading.Tasks;
using System;
using NgUtil.Maths;

namespace NgUtil.Hashing {
    public static class Hasher {


        public static HashResult HashSha512(string input) {
            return HashSha512(input, Encoding.UTF8);
        }

        public static HashResult HashSha512(string input, Encoding encoding) {
            EmptyParamContract.Validate(input);
            EmptyParamContract.Validate(encoding);
            
            return HashSha512(encoding.GetBytes(input));
        }

        public static HashResult HashSha512(byte[] bytes) {
            EmptyParamContract.Validate(bytes);

            using (SHA512 sha512 = SHA512.Create()) {
                return Hash(bytes, sha512);
            }
        }

        public static HashResult HashSha256(string input) {
            return HashSha256(input, Encoding.UTF8);
        }

        public static HashResult HashSha256(string input, Encoding encoding) {
            EmptyParamContract.Validate(input);
            EmptyParamContract.Validate(encoding);

            return HashSha256(encoding.GetBytes(input));
        }

        public static HashResult HashSha256(byte[] bytes) {
            EmptyParamContract.Validate(bytes);

            using (SHA256 sha256 = SHA256.Create()) {
                return Hash(bytes, sha256);
            }
        }

        public static HashResult HashSha1(string input) {
            return HashSha1(input, Encoding.UTF8);
        }

        public static HashResult HashSha1(string input, Encoding encoding) {
            EmptyParamContract.Validate(input);
            EmptyParamContract.Validate(encoding);

            return HashSha1(encoding.GetBytes(input));
        }

        public static HashResult HashSha1(byte[] bytes) {
            EmptyParamContract.Validate(bytes);

            using (SHA1 sha1 = SHA1.Create()) {
                return Hash(bytes, sha1);
            }
        }

        public static string RandomMD5(int length) {
            if (length > 32) {
                Console.WriteLine("Length can't be greater than 32");
                return RandomMD5(32);
            }
            string hash = HashMD5(MathUtil.GetUniqueId()).Hex;
            return hash.Substring(0, length);
        }

        public static HashResult HashMD5(string input) {
            return HashMD5(input, Encoding.ASCII);
        }
        public static HashResult HashMD5(string input, Encoding encoding) {
            EmptyParamContract.Validate(input);
            EmptyParamContract.Validate(encoding);
            return HashMD5(encoding.GetBytes(input));
        }

        public static async Task<HashResult> HashMD5(FileLink fileLink) {
            EmptyParamContract.Validate(fileLink);

            byte[] bytes = await File.ReadAllBytesAsync(fileLink.Path).ConfigureAwait(false);
            return await HashMD5Async(bytes).ConfigureAwait(false);
        }

        public static Task<HashResult> HashMD5Async(byte[] bytes) {
            EmptyParamContract.Validate(bytes);

            using (MD5 md5 = MD5.Create()) {
                return HashAsync(bytes, md5);
            }
        }

        public static HashResult HashMD5(byte[] bytes) {
            EmptyParamContract.Validate(bytes);

            using (MD5 md5 = MD5.Create()) {
                return Hash(bytes, md5);
            }
        }

        private static async Task<HashResult> HashAsync(byte[] bytes, HashAlgorithm hashAlgo) {
            return await Task.Run(() => HashAsync(bytes, hashAlgo)).ConfigureAwait(false);
        }

        private static HashResult Hash(byte[] bytes, HashAlgorithm hashAlgo) {
            return new HashResult(hashAlgo.ComputeHash(bytes));
        }

    }

}
