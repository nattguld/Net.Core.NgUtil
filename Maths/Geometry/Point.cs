using System;

namespace NgUtil.Maths.Geometry {
    public struct Point : IEquatable<Point> {

        public int X { get; set; }

        public int Y { get; set; }


        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            if (obj is null) {
                return false;
            }
            return Equals((Point)obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(Point left, Point right) {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right) {
            return !(left == right);
        }

        public bool Equals(Point other) {
            return other.X == X && other.Y == Y;
        }
    }
}
