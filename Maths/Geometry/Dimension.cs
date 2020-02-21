using System;

namespace NgUtil.Maths.Geometry {
    public struct Dimension : IEquatable<Dimension> {

        public int Width { get; set; }

        public int Height { get; set; }


        public Dimension(int width, int height) {
            Width = width;
            Height = height;
        }

        public override bool Equals(object obj) {
            if (obj is null) {
                return false;
            }
            return Equals((Dimension)obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(Dimension left, Dimension right) {
            return left.Equals(right);
        }

        public static bool operator !=(Dimension left, Dimension right) {
            return !(left == right);
        }

        public bool Equals(Dimension other) {
            return other.Width == Width && other.Height == Height;
        }
    }
}
