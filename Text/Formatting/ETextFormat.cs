using NgUtil.Generics.Enums;

namespace NgUtil.Text.Formatting {
    public class ETextFormat : ExtendedEnum<ETextFormat> {

        public string Format { get; }


        public ETextFormat(string name, string format) : base(name) {
            Format = format;
        }

    }
}
