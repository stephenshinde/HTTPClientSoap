using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QAChallenge.Helpers
{
    public class HttpClientHelper
    {
       private static HttpClient httpclient;
       private static HttpRequestMessage httpRequestMessage;

       public static Task<HttpResponseMessage> CreateHttpRequestMessage(string requestURI, string xmlData , Encoding encoding , string mediaType)
        {
            HttpClient httpclient = new HttpClient();
            HttpContent content = new StringContent(xmlData, Encoding.UTF8, "text/xml");

            Task<HttpResponseMessage> postResponse = httpclient.PostAsync(requestURI, content);

            return postResponse;
        }
    }
}
