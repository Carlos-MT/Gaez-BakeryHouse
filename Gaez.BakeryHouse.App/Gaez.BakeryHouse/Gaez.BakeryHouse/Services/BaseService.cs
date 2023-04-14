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
                BaseAddress = new Uri("https://7e4e-187-254-105-199.ngrok-free.app/")
            };
        }
    }
}
