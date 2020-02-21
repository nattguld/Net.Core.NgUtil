using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Generics {
    public class CustomizableListCollection<T> : List<T> {


        public CustomizableListCollection(List<T> list) : base(list) { }

        public CustomizableListCollection<T> Replace(T originalElement, T newElement) {
            int index = IndexOf(originalElement);

            Remove(originalElement);
            Insert(index, newElement);

            return this;
        }

        public CustomizableListCollection<T> MoveUp(T element) {
            int index = IndexOf(element);

            if (index != 0) {
                T above = this[index - 1];

                Remove(above);
                Insert(index, above);
            }
            return this;
        }

        public CustomizableListCollection<T> MoveDown(T element) {
            int index = IndexOf(element);

            if (index != (Count - 1)) {
                T below = this[(index + 1)];

                Remove(below);
                Insert(index, below);
            }
            return this;
        }

    }
}
