using NgUtil.Generics.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NgUtil.Files.IO.Json
{
    public sealed class EnumSupportiveJsonConverterFactory : JsonConverterFactory {



        public EnumSupportiveJsonConverterFactory() {
            // An empty constructor is needed for construction via attributes
        }

        public override bool CanConvert(Type typeToConvert) {
            return typeToConvert.IsSubclassOf(typeof(BaseEnumExtension));
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
            return new EnumExtensionJsonConverter<BaseEnumExtension>();
        }
    }
}
