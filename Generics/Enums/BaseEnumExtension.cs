using NgUtil.Files.IO.Json.Attributes;
using System;

namespace NgUtil.Generics.Enums {
    [InconvertableObject]
    //[JsonConverter(typeof(EnumExtensionJsonConverter<BaseEnumExtension>))]
    public abstract class BaseEnumExtension {

        public string NameIdentifier { get; private set; }


        protected BaseEnumExtension(string nameIdentifier) {
            if (string.IsNullOrEmpty(nameIdentifier)) {
                throw new ArgumentException("No proper name identifier is defined (" + nameIdentifier + ")");
            }
            NameIdentifier = nameIdentifier;
        }

    }
}
