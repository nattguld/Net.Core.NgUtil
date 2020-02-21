using NgUtil.Debugging.Contracts;
using System.Collections.Generic;

namespace NgUtil.Generics {
    public class GenericQueueContainer<T> : GenericContainer<T> {

        private readonly Queue<T> queue = new Queue<T>();


        public override GenericContainer<T> AddElement(T element) {
            EmptyParamContract.Validate(element);

            queue.Enqueue(element);
            return base.AddElement(element);
        }

        public virtual T NextElement() {
            if (IsQueueEmpty()) {
                return default;
            }
            return queue.Dequeue();
        }

        public GenericQueueContainer<T> ResetQueue() {
            queue.Clear();
            Elements.ForEach(e => queue.Enqueue(e));
            return this;
        }

        public bool IsQueueEmpty() {
            return queue.Count == 0;
        }

        public int GetQueueSize() {
            return queue.Count;
        }

    }
}
