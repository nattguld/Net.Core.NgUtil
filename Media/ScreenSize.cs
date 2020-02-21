using NgUtil.Debugging.Contracts;
using NgUtil.Generics.Enums;
using NgUtil.Maths.Geometry;
using System;

namespace NgUtil.Media {
    public sealed class ScreenSize : ExtendedEnum<ScreenSize> {

        public int Width { get; }

        public int Height { get; }

        public string PixelNotation { get; }


        private ScreenSize(string name, int width, int height, string pixelNotation) : base(name) {
            Width = width;
            Height = height;
            PixelNotation = pixelNotation;
        }

        public bool IsHD() {
            return this == ScreenSize.HD || this == ScreenSize.HDPlus
                    || this == ScreenSize.FullHD || this == ScreenSize.QHD
                    || this == ScreenSize.UltraHD;
        }

        public Dimension GetDimension() {
            return new Dimension(Width, Height);
        }

        public override string ToString() {
            return NameIdentifier + " (" + Width + ":" + Height + "px)";
        }

        public static ScreenSize[] GetHightToLow() {
            ScreenSize[] pts = new ScreenSize[Values().Count];

            pts[0] = ScreenSize.EightK;
            pts[1] = ScreenSize.UltraHD;
            pts[2] = ScreenSize.QHD;
            pts[3] = ScreenSize.FullHD;
            pts[4] = ScreenSize.HDPlus;
            pts[5] = ScreenSize.HD;
            pts[6] = ScreenSize.XGA;
            pts[7] = ScreenSize.SVGA;
            pts[8] = ScreenSize.VGA;
            pts[9] = ScreenSize.Wide;
            pts[10] = ScreenSize.NtscWide;
            pts[11] = ScreenSize.Ntsc;

            return pts;
        }

        public static bool IsHigherQualityThan(ScreenSize original, ScreenSize toCheck) {
            EmptyParamContract.Validate(original != null && toCheck != null);

            foreach (ScreenSize sz in GetHightToLow()) {
                if (sz == original) {
                    return false;
                }
                if (sz == toCheck) {
                    return true;
                }
            }
            return true;
        }

        public static ScreenSize GetByPixelNotation(string pixelNotation) {
            EmptyParamContract.Validate(pixelNotation);

            if (!pixelNotation.EndsWith("p", StringComparison.Ordinal)) {
                pixelNotation += "p";
            }
            pixelNotation = pixelNotation.Replace(" ", "", StringComparison.Ordinal);

            foreach (ScreenSize sz in ScreenSize.Values()) {
                if (sz.PixelNotation.Equals(pixelNotation, StringComparison.Ordinal)) {
                    return sz;
                }
            }
            return null;
        }

        public static ScreenSize GetByResolution(int width, int height, bool closest) {
            ScreenSize sz = null;

            foreach (ScreenSize o in Values()) {
                if (o.Width == width && o.Height == height) {
                    return o;
                }
                if (!closest) {
                    continue;
                }
                if (sz == null) {
                    sz = o;
                    continue;
                }
                int currWidthDiff = Math.Abs(sz.Width - width);
                int currHeightDiff = Math.Abs(sz.Height - height);

                int newWidthDiff = Math.Abs(sz.Width - width);
                int newHeightDiff = Math.Abs(sz.Height - height);

                if ((currWidthDiff + currHeightDiff) >= (newWidthDiff + newHeightDiff)) {
                    sz = o;
                }
            }
            Console.WriteLine("Dimensions[" + width + ":" + height + "] Closest[" + sz.Width + ":" + sz.Height + " (" + sz.NameIdentifier + ")]");
            return sz;
        }

        public static readonly ScreenSize Ntsc = new ScreenSize("240p", 320, 240, "240p");
        public static readonly ScreenSize NtscWide = new ScreenSize("240p", 426, 240, "240p");
        public static readonly ScreenSize Wide = new ScreenSize("360p", 640, 360, "360p");
        public static readonly ScreenSize VGA = new ScreenSize("VGA", 640, 480, "480p");
        public static readonly ScreenSize SVGA = new ScreenSize("SVGA", 800, 600, "600p");
        public static readonly ScreenSize XGA = new ScreenSize("XGA", 1024, 768, "768p");
        public static readonly ScreenSize HD = new ScreenSize("HD 720p", 1280, 720, "720p");
        public static readonly ScreenSize HDPlus = new ScreenSize("HD+ 900p", 1600, 900, "900p");
        public static readonly ScreenSize FullHD = new ScreenSize("FHD 1080p", 1920, 1080, "1080p");
        public static readonly ScreenSize QHD = new ScreenSize("QHD 1440p", 2560, 1440, "1440p");
        public static readonly ScreenSize UltraHD = new ScreenSize("UHD 2160p", 3840, 2160, "2160p");
        public static readonly ScreenSize EightK = new ScreenSize("8K 4320p", 7680, 4320, "4320p");

    }
}
