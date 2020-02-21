using NgUtil.Debugging.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Generics {
    public class GenericContainer<T> {

        protected List<T> Elements { get; } = new List<T>();


        public GenericContainer<T> AddElements(List<T> newElements) {
            EmptyParamContract.Validate(newElements);

            foreach (T element in newElements) {
                AddElement(element);
            }
            return this;
        }

        public virtual GenericContainer<T> AddElement(T element) {
            EmptyParamContract.Validate(element);

            Elements.Add(element);
            return this;
        }

        public bool IsContainerEmpty() {
            return Elements.Count == 0;
        }

        public int GetContainerSize() {
            return Elements.Count;
        }

        public GenericQueueContainer<T> Copy() {
            GenericQueueContainer<T> copy = new GenericQueueContainer<T>();
            copy.AddElements(GenericsHelper.DeepCopy(Elements));
            return copy;
        }

    }
}
