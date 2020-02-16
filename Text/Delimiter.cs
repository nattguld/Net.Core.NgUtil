using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Text {
    public sealed class Delimiter {

        public string Character { get; }


        private Delimiter(string character) {
            Character = character;
        }

        public override string ToString() {
            return Character;
        }

        public static readonly Delimiter ANGLE_BRACKET_OPEN = new Delimiter("<");
        public static readonly Delimiter ANGLE_BRACKET_CLOSE = new Delimiter(">");
        public static readonly Delimiter APOSTROPHE = new Delimiter("'");
        public static readonly Delimiter ASTERISK = new Delimiter("*");
        public static readonly Delimiter BACKSLASH = new Delimiter("\\");
        public static readonly Delimiter SLASH = new Delimiter("/");
        public static readonly Delimiter BRACKET_OPEN = new Delimiter("(");
        public static readonly Delimiter BRACKET_CLOSE = new Delimiter(")");
        public static readonly Delimiter COLON = new Delimiter(":");
        public static readonly Delimiter SEMI_COLON = new Delimiter(";");
        public static readonly Delimiter CURLY_BRACKET_OPEN = new Delimiter("{");
        public static readonly Delimiter CURLY_RACKET_CLOSE = new Delimiter("}");
        public static readonly Delimiter MINUS = new Delimiter("-");
        public static readonly Delimiter QUOTATION_MARK = new Delimiter("\"");
        public static readonly Delimiter EXCLAMATION_MARK = new Delimiter("!");
        public static readonly Delimiter PERIOD = new Delimiter(".");
        public static readonly Delimiter QUESTION_MARK = new Delimiter("?");
        public static readonly Delimiter SQUARE_BRACKET_OPEN = new Delimiter("[");
        public static readonly Delimiter SQUARE_BRACKET_CLOSE = new Delimiter("]");
        public static readonly Delimiter UNDERSCORE = new Delimiter("_");
        public static readonly Delimiter HASHTAG = new Delimiter("#");
        public static readonly Delimiter AT = new Delimiter("@");
        public static readonly Delimiter CARET = new Delimiter("^");
        public static readonly Delimiter TIDLE = new Delimiter("~");
        public static readonly Delimiter PLUS = new Delimiter("+");
        public static readonly Delimiter EQUAL = new Delimiter("=");
        public static readonly Delimiter PIPE = new Delimiter("|");
        public static readonly Delimiter SPACE = new Delimiter(" ");
        public static readonly Delimiter TAB = new Delimiter("\t");
        public static readonly Delimiter LINEBREAK = new Delimiter("\r\n");
        public static readonly Delimiter NEW_LINE = new Delimiter("\n");
        public static readonly Delimiter BACKSPACE = new Delimiter("\b");
        public static readonly Delimiter ENTER = new Delimiter("\r");
        public static readonly Delimiter FORM_FEED = new Delimiter("\f");

    }
}
