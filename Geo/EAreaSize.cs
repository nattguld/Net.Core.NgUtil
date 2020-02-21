using NgUtil.Files.IO.Json;
using NgUtil.Generics.Enums;
using System.Text.Json.Serialization;

namespace NgUtil.Geo {
    public sealed class EAreaSize : ExtendedEnum<EAreaSize> {

        public double Radius { get; }


        private EAreaSize(string name, double radius) : base(name) {
            Radius = radius;
            
        }

        public static readonly EAreaSize Appartment = new EAreaSize("Appartment", 0.0001);
        public static readonly EAreaSize House = new EAreaSize("House", 0.0002);
        public static readonly EAreaSize Block = new EAreaSize("Block", 0.001);
        public static readonly EAreaSize Village = new EAreaSize("Village", 0.005);
        public static readonly EAreaSize SmallCity = new EAreaSize("Small City", 0.01);
        public static readonly EAreaSize MediumCity = new EAreaSize("Medium City", 0.02);
        public static readonly EAreaSize BigCity = new EAreaSize("Big City", 0.05);
        public static readonly EAreaSize LargeCity = new EAreaSize("Large City", 0.1);
        public static readonly EAreaSize Metropol = new EAreaSize("Metropol", 0.2);

    }
}
