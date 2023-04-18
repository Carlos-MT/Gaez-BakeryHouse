using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Gaez.BakeryHouse.Services
{
    public class BaseService
    {
        public HttpClientHandler handler { get; set; }
        public HttpClient httpClient { get; set; }
        public BaseService()
        {
            handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://e570-187-254-97-203.ngrok-free.app/")
            };
        }
    }
}
