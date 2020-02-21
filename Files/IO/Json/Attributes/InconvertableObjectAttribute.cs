using System;

namespace NgUtil.Files.IO.Json.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false) ]
    public class InconvertableObjectAttribute : Attribute { }
}
