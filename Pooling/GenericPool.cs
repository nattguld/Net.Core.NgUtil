using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Pooling {
    public abstract class GenericPool<T> {

        public List<T> IdlePool { get; }

        public List<T> ActivePool { get; }

        public int MaxPoolSize { get; set; }


        public GenericPool(int maxPoolSize) {
            MaxPoolSize = MaxPoolSize;
            IdlePool = new List<T>();
            ActivePool = new List<T>();
        }

        public abstract T CreateElement();

        public T GetElement() {
            T element = (T)CallIdleElement();

            if (element is null) {
                if (!HasRoom()) {
                    Console.WriteLine("All pool elements currently in use, trying again in 10 seconds");
                    Misc.Sleep(1000);
                    return GetElement();
                }
                element = CreateElement();

                if (element is null) {
                    throw new Exception("Failed to create new pool element");
                }
            }
            ActivePool.Add(element);
            return element;
        }

        protected object CallIdleElement() {
            if (IdlePool.Count == 0) {
                return null;
            }
            T element = IdlePool[0];
            IdlePool.RemoveAt(0);
            return element;
        }

        public GenericPool<T> Release(T element) {
            if (element is null) {
                return this;
            }
            ActivePool.Remove(element);

            if (HasRoom()) {
                IdlePool.Add(element);
            }
            return this;
        }

        public int GetPoolSize() {
            return IdlePool.Count + ActivePool.Count;
        }

        public bool HasRoom() {
            return MaxPoolSize < 1 || GetPoolSize() < MaxPoolSize;
        }

        public GenericPool<T> ClearIdles() {
            IdlePool.Clear();
            return this;
        }

        public GenericPool<T> Shutdown() {
            IdlePool.Clear();
            ActivePool.Clear();
            return this;
        }

    }
}
