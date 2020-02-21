using NgUtil.Generics.Enums;

namespace NgUtil.Text {
    public sealed class ETextSeed : ExtendedEnum<ETextSeed> {

        private readonly string[] Characters;


        private ETextSeed(string name, string[] characters) : base(name) {
            Characters = characters;
        }

        public string[] GetCharacters() {
            return (string[])Characters.Clone();
        }

        public static readonly ETextSeed Lowercase = new ETextSeed("Lowercase", new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i"
            , "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"});
        public static readonly ETextSeed Uppercase = new ETextSeed("Uppercase", new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I"
            , "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
        public static readonly ETextSeed Symbols = new ETextSeed("Symbols", new string[] { "*", "$", "%", "-", "+", "(", ")", "{", "}", "_", ";", "=", "!", "&" });
        public static readonly ETextSeed Digits = new ETextSeed("Digits", new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });

    }
}
