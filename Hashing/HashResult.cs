using System;

namespace NgUtil.Hashing {
    public struct HashResult : IEquatable<HashResult> {

        public string Hex { get; }

        private readonly byte[] HashedBytes;


        public HashResult(byte[] hashedBytes) {
            HashedBytes = hashedBytes;
            Hex = Converter.BytesToHexAlt(hashedBytes);
        }

        public byte[] Bytes() {
            return (byte[])HashedBytes.Clone();
        }

        public override bool Equals(object obj) {
            if (obj is null) {
                return false;
            }
            return Equals((HashResult)obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(HashResult left, HashResult right) {
            return left.Equals(right);
        }

        public static bool operator !=(HashResult left, HashResult right) {
            return !(left == right);
        }

        public bool Equals(HashResult other) {
            return Hex.Equals(Hex, StringComparison.Ordinal);
        }
    }
}
