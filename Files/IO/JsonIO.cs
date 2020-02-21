using NgUtil.Debugging.Contracts;
using NgUtil.Files.IO.Json;
using NgUtil.Files.IO.Json.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace NgUtil.Files.IO {
    public static class JsonIO {


        public static void ParseFile(string filePath, IJsonDocumentReader reader) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(filePath) && reader != null);

            string json = TextIO.GetContent(filePath);
            ParseString(json, reader);
        }

        public static void ParseFile(string filePath, IJsonDocumentReader reader, JsonDocumentOptions jsonDocOptions) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(filePath) && reader != null);

            string json = TextIO.GetContent(filePath);
            ParseString(json, reader, jsonDocOptions);
        }

        public static void ParseString(string json, IJsonDocumentReader reader, JsonDocumentOptions jsonDocOptions) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(json) && reader != null);

            using (JsonDocument jsonDoc = JsonDocument.Parse(json, jsonDocOptions)) {
                reader.Read(jsonDoc);
            }
        }

        public static void ParseString(string json, IJsonDocumentReader reader) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(json) && reader != null);
            
            using (JsonDocument jsonDoc = JsonDocument.Parse(json)) {
                reader.Read(jsonDoc);
            }
        }

        public static void LoadJsonResources<T>(byte[] resource, List<T> list) {
            EmptyParamContract.Validate(resource != null && resource.Length > 0 && list != null);

            list.Clear();

            foreach (T element in DeserializeObject<T[]>(resource)) {
                list.Add(element);
            }
        }

        public static T LoadObject<T>(string filePath, bool relaxed = false) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(filePath));

            string json = TextIO.GetContent(filePath);
            return DeserializeObject<T>(json, relaxed);
        }

        public static T DeserializeObject<T>(byte[] bytes, bool relaxed = false) {
            EmptyParamContract.Validate(bytes != null);

            JsonSerializerOptions options = relaxed ? new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            } : new JsonSerializerOptions {
                WriteIndented = true
            };
            options.Converters.Add(new EnumSupportiveJsonConverterFactory());
            return JsonSerializer.Deserialize<T>(bytes, options);
        }

        public static T DeserializeObject<T>(string json, bool relaxed = false) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(json));

            JsonSerializerOptions options = relaxed ? new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            } : new JsonSerializerOptions {
                WriteIndented = true
            };
            options.Converters.Add(new EnumSupportiveJsonConverterFactory());
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static string SerializeObject<T>(T jsonObject, bool relaxed = false) {
            EmptyParamContract.Validate(jsonObject != null);

            JsonSerializerOptions options = relaxed ? new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            } : new JsonSerializerOptions {
                WriteIndented = true
            };
            object[] attrs = jsonObject.GetType().GetCustomAttributes(true);

            foreach (Attribute attr in attrs) {
                Console.WriteLine(attr);

                if (attr.GetType() == typeof(InconvertableObjectAttribute)) {
                    throw new Exception(jsonObject.GetType().Name + " can not be serialized, it implements the InconvertableObject attribute");
                }
            }
            options.Converters.Add(new EnumSupportiveJsonConverterFactory());
            return JsonSerializer.Serialize<T>(jsonObject, options);
        }

        public static string SerializeObject<T>(T jsonObject) {
            return SerializeObject<T>(jsonObject, false);
        }

        public static void SaveObject<T>(string filePath, T jsonObject) {
            SaveObject<T>(filePath, jsonObject, false);
        }

        public static void SaveObject<T>(string filePath, T jsonObject, bool relaxed = false) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(filePath) && jsonObject != null);

            string json = SerializeObject<T>(jsonObject, relaxed);
            TextIO.WriteAsync(filePath, json);
        }

        public static void SaveJsonResource<T>(IJsonResource res, bool relaxed = false) {
            EmptyParamContract.Validate(res != null);

            SaveObject(res.GetSavePath(), res, relaxed);
        }

    }
}
