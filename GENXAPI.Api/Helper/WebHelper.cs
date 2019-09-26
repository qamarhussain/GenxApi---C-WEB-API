using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GENXAPI.Api.Helper
{
    public class WebHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="statusCode"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        public static HttpResponseMessage SendResponse<T>(T response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (statusCode == HttpStatusCode.OK)
                return new HttpResponseMessage(statusCode)
                {
                    Content =
                        new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
            var badResponse =
                new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };

            throw new HttpResponseException(badResponse);
        }
    }
}