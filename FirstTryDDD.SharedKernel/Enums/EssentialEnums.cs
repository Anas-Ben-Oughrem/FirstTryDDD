using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace FirstTryDDD.SharedKarnel.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResponseResult { None, Success, Exception, Error }
}