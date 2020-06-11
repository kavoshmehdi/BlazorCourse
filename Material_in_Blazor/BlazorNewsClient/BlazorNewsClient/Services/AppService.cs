using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorNewsClient.Services
{
    public class AppService
    {
        private readonly HttpClient _http;

        public AppService(HttpClient http)
        {
            _http = http;
        }
        //public async Task Load()
        //{

        //}
    }
}
