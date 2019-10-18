using System.Text.Json.Serialization;

namespace SDigital.Models
{
    public class BaseResponse
    {
        [JsonIgnore]
        public int StatusCode { get; set; }

        public string Mensagem { get; set; }
    }
}