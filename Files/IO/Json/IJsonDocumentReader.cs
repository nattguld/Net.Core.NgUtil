using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NgUtil.Files.IO.Json {
    public interface IJsonDocumentReader {


        public void Read(JsonDocument jsonDoc);
        
    }
}
