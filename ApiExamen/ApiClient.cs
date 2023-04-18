using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiExamen
{
    internal class ApiClient
    {
        internal async Task<string> AgregarAsync(string name, string description)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5121/api/examen");
            var requestContent = new { Name = name, Description = description };
            request.Content = new StringContent(JsonConvert.SerializeObject(requestContent));
            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return "Hubo un error";

            return "Insertado satisfactoriamente";
        }

        internal async Task<string> ActualizarAsync(string name, string description)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:5121/api/examen");
            var requestContent = new { Name = name, Description = description };
            request.Content = new StringContent(JsonConvert.SerializeObject(requestContent));
            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return "Hubo un error";

            return "Insertado satisfactoriamente";
        }

        internal async Task<string> EliminarAsync(int id)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5121/api/examen");
            var requestContent = new { Name = name, Description = description };
            request.Content = new StringContent(JsonConvert.SerializeObject(requestContent));
            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return "Hubo un error";

            return "Insertado satisfactoriamente";
        }

        internal async Task<string> ConsultarAsync(string name, string description)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5121/api/examen");
            var requestContent = new { Name = name, Description = description };
            request.Content = new StringContent(JsonConvert.SerializeObject(requestContent));
            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return "Hubo un error";

            return "Insertado satisfactoriamente";
        }
    }   
        
}
