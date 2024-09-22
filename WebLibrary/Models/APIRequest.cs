using Microsoft.AspNetCore.Mvc;
using static WebLibrary.StaticDetails;

namespace WebLibrary.Models
{
    public class APIRequest
    {
        public APIType aPIType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
