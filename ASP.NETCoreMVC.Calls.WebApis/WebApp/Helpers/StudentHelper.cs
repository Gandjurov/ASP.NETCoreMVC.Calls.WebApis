using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Contracts;

namespace WebApp.Helpers
{
    public class StudentHelper : IHelper
    {
        public HttpClient Initial()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44369/");
            return client;
        }
    }
}
