using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;

namespace APITests
{
    [TestFixture]
    public class Lesson4BasicHttpClient
    {
        [Test]
        public void Sample_1_GetSimpleApi()
        {
            string uri = "https://jsonplaceholder.typicode.com/posts/1";

            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(uri);
            Task.WaitAll(response);

            var responseCode = response.Result.StatusCode;
            var responseContent = response.Result.Content;

            var responseContentAsString = response.Result.Content.ReadAsStringAsync().Result;
        }

        [Test]
        public void Sample_2_GetSimpleApiSimpler()
        {
            string uri = "https://jsonplaceholder.typicode.com/posts/1";

            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(uri);
            Task.WaitAll(response);

            var result = response.Result;
        }

        [Test]
        public void Sample_3_SendAsyncSimpleApi()
        {
            string uri = "https://jsonplaceholder.typicode.com/posts/1";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            //HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Get;
            //httpRequestMessage.RequestUri = new System.Uri(uri);

            HttpClient httpClient = new HttpClient();
            var response = httpClient.SendAsync(httpRequestMessage);
            Task.WaitAll(response);

            var result = response.Result;
        }

        ///https://jsonplaceholder.typicode.com/guide.html
        ///

        [Test]
        public void Sample_4_PostSimpleApi()
        {
            string uri = "https://jsonplaceholder.typicode.com/posts/1";
        }
    }
}