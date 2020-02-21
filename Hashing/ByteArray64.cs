using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NgUtil.Hashing {
    public sealed class ByteArray64 {

        private const long CHUNK_SIZE = 1024 * 1024 * 1024; //1GiB

        public long Size { get; private set; }

        private byte[][] data;


        public ByteArray64(long size) {
            Size = size;

            if (Size == 0) {
                data = null;
            } else {
                int chunks = (int)(Size / CHUNK_SIZE);
                int remainder = (int)(Size - ((long)chunks) * CHUNK_SIZE);
                data = new byte[chunks + (remainder == 0 ? 0 : 1)][];
                for (int idx = chunks; --idx >= 0;) {
                    data[idx] = new byte[(int)CHUNK_SIZE];
                }
                if (remainder != 0) {
                    data[chunks] = new byte[remainder];
                }
            }
        }

        public byte Get(long index) {
            if (index < 0 || index >= Size) {
                throw new IndexOutOfRangeException("Error attempting to access data element " + index + ".  Array is " + Size + " elements long.");
            }
            int chunk = (int)(index / CHUNK_SIZE);
            int offset = (int)(index - (((long)chunk) * CHUNK_SIZE));
            return data[chunk][offset];
        }

        public void Set(long index, byte b) {
            if (index < 0 || index >= Size) {
                throw new IndexOutOfRangeException("Error attempting to access data element " + index + ".  Array is " + Size + " elements long.");
            }
            int chunk = (int)(index / CHUNK_SIZE);
            int offset = (int)(index - (((long)chunk) * CHUNK_SIZE));
            data[chunk][offset] = b;
        }

        /**
         * Simulates a single read which fills the entire array via several smaller reads.
         * 
         * @param fileInputStream
         * @throws IOException
         */
        public void Read(FileStream fileInputStream) {
            if (Size == 0 ) {
                return;
            }
            for(int idx=0; idx<data.Length; idx++ ) {
                if(fileInputStream.Read(data[idx] ) != data[idx].Length ) {
                    throw new Exception("short read");
                }
        }
    }
    

    }
}
