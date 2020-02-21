using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NgUtil.Debugging.Contracts {
    public static class EmptyParamContract {


        public static void Validate(bool predicate, string message = null) {
            if (predicate) {
                return;
            }
            if (!string.IsNullOrEmpty(message)) {
                Debug.WriteLine(message);
            }
            //throw new ArgumentNullException();
            throw new NullReferenceException();
        }

        public static void Validate(object objectParam) {
            if (objectParam is null) {
                throw new NullReferenceException();
            }
        }

        public static void Validate(string stringParam, bool allowEmpty = false) {
            if (stringParam is null || (!allowEmpty && stringParam.Length == 0)) {
                throw new NullReferenceException();
            }
        }

    }
}
