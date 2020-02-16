using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Text {
    public class HtmlFormatter {

        public const string Space = "&nbsp;";

        public const string NewLine = "<br>";


        public static string Tags(string input, string tag) {
            return "<" + tag + ">" + input + "</" + tag + ">";
        }

        public static string Html(string input) {
            return Tags(input, "html");
        }

        public static string Bold(string input) {
            return Tags(input, "b");
        }

        public static string Italics(string input) {
            return Tags(input, "i");
        }

        public static string Underlined(string input) {
            return Tags(input, "u");
        }

        public static string Colored(string input, string color) {
            return "<font color=" + color + ">" + input + "</font>";
        }

    }
}
