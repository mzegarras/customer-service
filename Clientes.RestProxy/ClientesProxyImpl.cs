using System;
using System.Net.Http;

namespace Clientes.RestProxy
{
    public class ClientesProxyImpl : ClientesProxy
    {
        public string list()
        {
             HttpClient httpClient = new HttpClient();
             
            httpClient.BaseAddress = new Uri("http://internal-PrivateELB-413244230.us-east-1.elb.amazonaws.com");

             var response = httpClient.GetAsync("/api/clientes",HttpCompletionOption.ResponseContentRead).GetAwaiter().GetResult();

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().Result;

            return content;
        }
    }
}
