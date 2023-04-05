using FirstTryDDD.SharedKarnel.Enums;
using System.Text.Json.Serialization;

namespace FirstTryDDD.SharedKernel.Models
{

    #region Response
    public class Response
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResponseResult Result { get; set; }
        public StatusCode Status { get; set; }

    }
    #endregion

    #region GlobalResponse
    public class GlobalResponse : Response
    {
        public dynamic Object { get; set; }
    }
    #endregion

    #region SimpleErrorResponse
    public class SimpleErrorResponse : Response
    {
        public string MsgException { get; set; }
    }
    #endregion

    #region DetailedErrorResponse
    public class DetailedErrorResponse : Response
    {
        public ResponseException Exception { get; set; }
    }
    #endregion

    /*****************************************************************/
    public class ResponseException
    {
        public string Message { get; set; }
        public string AdditionalMessage { get; set; }
        //public string[] Errors { get; set; }
    }

}

