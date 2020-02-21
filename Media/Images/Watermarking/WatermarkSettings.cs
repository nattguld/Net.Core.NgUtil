using SixLabors.Fonts;
using SixLabors.ImageSharp;
using System;

namespace NgUtil.Media.Images.Watermarking {
    public struct WatermarkSettings : IEquatable<WatermarkSettings> {

        public Color Color { get; set; }

        public Font Font { get; set; }

        public int Padding { get; set; }

        public bool IsWordWrap { get; set; }


        public WatermarkSettings(int fontSize = 10) {
            Color = Color.White;
            Font = SystemFonts.CreateFont("Arial", fontSize);
            Padding = 5;
            IsWordWrap = true;
        }

        public override bool Equals(object obj) {
            if (obj is null) {
                return false;
            }
            return Equals((WatermarkSettings)obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(WatermarkSettings left, WatermarkSettings right) {
            return left.Equals(right);
        }

        public static bool operator !=(WatermarkSettings left, WatermarkSettings right) {
            return !(left == right);
        }

        public bool Equals(WatermarkSettings other) {
            return other.GetHashCode() == GetHashCode();
        }
    }
}
