using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Geo.Location {
    public sealed class StateRegion {

        public string Name { get; }

        public string Abbreviation { get; }


        public StateRegion(string name, string abbreviation) {
            Name = name;
            Abbreviation = abbreviation;
        }

    }
}
