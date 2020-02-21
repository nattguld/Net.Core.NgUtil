using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Generics.Kvps {
    public class KeyValuePair<TK, TV> {

        public TK Key { get; }

        public TV Value { get; set; }


        public KeyValuePair(TK key, TV value) {
            Key = key;
            Value = value;
        }

    }
}
