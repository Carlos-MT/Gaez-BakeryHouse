﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Gaez.BakeryHouse.Services
{
    public class BaseService
    {
        public HttpClientHandler handler { get; private set; }
        public HttpClient httpClient { get; private set; }
        public BaseService()
        {
            handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://53ae-187-254-100-211.ngrok-free.app/")
            };
        }
    }
}
