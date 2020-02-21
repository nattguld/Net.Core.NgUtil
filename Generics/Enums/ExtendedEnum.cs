using NgUtil.Debugging.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NgUtil.Generics.Enums {
    public abstract class ExtendedEnum<T> : BaseEnumExtension where T : ExtendedEnum<T> {

        private static readonly List<T> values = new List<T>();

#pragma warning disable CA1000 // Do not declare static members on generic types
        public static int Count => Values().Count;
#pragma warning restore CA1000 // Do not declare static members on generic types

        public int Ordinal { get; }


        protected ExtendedEnum(string nameIdenfifier) : base(nameIdenfifier) {
            Ordinal = Count;
            values.Add((T)this);
        }

        public override bool Equals(object other) {
            if (other is null) {
                return false;
            }
            return other.GetType() == GetType();
        }

        public override int GetHashCode() {
            return Ordinal;
        }

        public override string ToString() {
            return NameIdentifier;
        }

#pragma warning disable CA1000 // Do not declare static members on generic types
        public static List<T> Values() {
#pragma warning restore CA1000 // Do not declare static members on generic types
            if (values.Count == 0) {
                RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
            }
            return values;
        }

#pragma warning disable CA1000 // Do not declare static members on generic types
        public static T GetByOrdinal(int ordinal) {
#pragma warning restore CA1000 // Do not declare static members on generic types
            foreach (T element in values) {
                if (element.Ordinal == ordinal) {
                    return element;
                }
            }
            Debug.WriteLine("Failed to find enum extension with given ordinal => " + ordinal);
            return null;
        }

#pragma warning disable CA1000 // Do not declare static members on generic types
        public static T GetByNameIdentifier(string nameIdentifier) {
#pragma warning restore CA1000 // Do not declare static members on generic types
            EmptyParamContract.Validate(nameIdentifier);

            foreach (T element in values) {
                if (element.NameIdentifier.Equals(nameIdentifier, StringComparison.OrdinalIgnoreCase)) {
                    return element;
                }
            }
            Debug.WriteLine("Failed to find enum extension with given name => " + nameIdentifier);
            return null;
        }

    }
}
