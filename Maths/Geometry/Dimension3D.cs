using System;

namespace NgUtil.Maths.Geometry {
    public struct Dimension3D : IEquatable<Dimension3D> {

        public int Width { get; set; }

        public int Height { get; set; }

        public int Depth { get; set; }


        public Dimension3D(int width, int height, int depth) {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public override bool Equals(object obj) {
            if (obj is null) {
                return false;
            }
            return Equals((Dimension3D)obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(Dimension3D left, Dimension3D right) {
            return left.Equals(right);
        }

        public static bool operator !=(Dimension3D left, Dimension3D right) {
            return !(left == right);
        }

        public bool Equals(Dimension3D other) {
            return other.Width == Width && other.Height == Height && other.Depth == Depth;
        }
    }
}
