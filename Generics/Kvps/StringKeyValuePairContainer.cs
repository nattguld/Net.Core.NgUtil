using NgUtil.Debugging.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Generics.Kvps {
    public class StringKeyValuePairContainer<T, TV> where T : KeyValuePair<string, TV> {

        public List<T> Kvps { get; } = new List<T>();


        public StringKeyValuePairContainer<T, TV> Put(T kvp, bool ignoreCase = true) {
            EmptyParamContract.Validate(kvp);

            T exists = Get(kvp.Key, ignoreCase);

            if (exists != default) {
                exists.Value = kvp.Value;
                return this;
            }
            Kvps.Add(kvp);
            return this;
        }

        public T Get(string key, bool ignoreCase = true) {
            EmptyParamContract.Validate(key);

            foreach (T kvp in Kvps) {
                if (kvp.Key.Equals(key, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) {
                    return kvp;
                }
            }
            return default;
        }

        public StringKeyValuePairContainer<T, TV> Remove(T kvp, bool ignoreCase = true) {
            EmptyParamContract.Validate(kvp);

            T exists = Get(kvp.Key, ignoreCase);

            if (exists != default) {
                Kvps.Remove(exists);
            }
            return this;
        }

    }
}
