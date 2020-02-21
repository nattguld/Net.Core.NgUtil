using System;

namespace NgUtil.Maths.Geometry {
    public struct Point3D : IEquatable<Point3D> {

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }


        public Point3D(int x, int y, int z) {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj) {
            if (obj is null) {
                return false;
            }
            return Equals((Point3D)obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(Point3D left, Point3D right) {
            return left.Equals(right);
        }

        public static bool operator !=(Point3D left, Point3D right) {
            return !(left == right);
        }

        public bool Equals(Point3D other) {
            return other.X == X && other.Y == Y && other.Z == Z;
        }
    }
}
