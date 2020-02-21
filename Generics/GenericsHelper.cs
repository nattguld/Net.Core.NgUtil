using NgUtil.Debugging.Contracts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NgUtil.Generics {
    public static class GenericsHelper {

        public static T DeepCopy<T>(T input) {
            EmptyParamContract.Validate(input);

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, input);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }

    }
}
