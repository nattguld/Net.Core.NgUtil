using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Text {
    public sealed class TextSeed {

        public string[] Characters { get; }


        private TextSeed(string[] characters) {
            Characters = characters;
        }

        public static readonly TextSeed LOWERCASE = new TextSeed(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i"
            , "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"});
        public static readonly TextSeed UPPERCASE = new TextSeed(new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I"
            , "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
        public static readonly TextSeed SYMBOLS = new TextSeed(new string[] { "*", "$", "%", "-", "+", "(", ")", "{", "}", "_", ";", "=", "!", "&" });
        public static readonly TextSeed DIGITS = new TextSeed(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });

    }
}
