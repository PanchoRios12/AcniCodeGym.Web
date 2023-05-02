using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AcniCodeGym.Service.Base
{
    public static class GenericMethodsAPIClient<T> where T : class
    {
        public static async Task<T> Get(string endPoint, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.GetAsync(endPoint).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"{error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> GetById(string endPoint, int id, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.GetAsync(endPoint + $"/{id}").Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"{error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> Post(string endPoint, object value, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.PostAsJsonAsync(endPoint, value).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"{error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> Put(string endPoint, int? id, object value, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = id is null ? client.PutAsJsonAsync(endPoint, value).Result : client.PutAsJsonAsync(endPoint + $"/{id}", value).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"{error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> Delete(string endPoint, int id, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.DeleteAsync(endPoint + $"/{id}").Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"{error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

    }
}
