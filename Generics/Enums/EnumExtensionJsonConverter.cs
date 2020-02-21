using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NgUtil.Generics.Enums {
    public sealed class EnumExtensionJsonConverter<T> : JsonConverter<T> where T : BaseEnumExtension {


        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            if (!typeToConvert.IsSubclassOf(typeof(BaseEnumExtension))) {
                throw new ArgumentException("Received non-enum extension argument in enum extension json converter => " + typeToConvert.Name);
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
            //writer.WriteString(value.GetType().Name, value.NameIdentifier);
            writer.WriteStringValue(value.NameIdentifier);
        }

    }
}
