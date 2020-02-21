using NgUtil.Generics.Enums;

namespace NgUtil.Media {
    public sealed class AspectRatio : ExtendedEnum<AspectRatio> {

        public int XRatio { get; }

        public int YRatio { get; }


        private AspectRatio(string name, int xRatio, int yRatio) : base(name) {
            XRatio = xRatio;
            YRatio = yRatio;
        }

        public double getRatio() {
            return (double)((double)XRatio / (double)YRatio);
        }

        public override string ToString() {
            return NameIdentifier + " (" + XRatio + ":" + YRatio + ")";
        }

        public static readonly AspectRatio Square = new AspectRatio("Square", 1, 1);
        public static readonly AspectRatio Wide = new AspectRatio("Wide", 2, 1);
        public static readonly AspectRatio Panoramic = new AspectRatio("Panoramic", 4, 1);
        public static readonly AspectRatio Standard = new AspectRatio("Standard", 4, 3);
        public static readonly AspectRatio HD = new AspectRatio("HD", 16, 9);
        public static readonly AspectRatio Monitor = new AspectRatio("Monitor", 16, 10);
        public static readonly AspectRatio Phone = new AspectRatio("Phone", 9, 16);
        public static readonly AspectRatio PhoneWidescreen = new AspectRatio("Phone Widescreen", 16, 9);
	
    }
}
