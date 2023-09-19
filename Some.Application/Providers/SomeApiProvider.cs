using Some.Domain.Models.DTOs;
using Some.Domain.Services;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Some.Application.Providers
{
    public class SomeApiProvider : ISomeApiProvider
    {
        private readonly HttpClient _client;

        private const string BASE_API = "";
        public SomeApiProvider()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(BASE_API)
            };
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _client.GetAsync(url);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Patch<T>(string url, object dto)
        {
            var response = await _client.PatchAsJsonAsync(url, dto);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Post<T>(string url, object dto)
        {
            var response = await _client.PostAsJsonAsync(url, dto);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Put<T>(string url, object dto)
        {
            var response = await _client.PutAsJsonAsync(url, dto);


            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<AuthorizationResultDTO> Authorize(LoginDTO dto)
        {
            var response = await _client.PostAsJsonAsync("", dto);

            var content = await response.Content.ReadFromJsonAsync<AuthorizationResultDTO>();

            if (content.IsSuccess)
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", content.Token);

            return content;
        }
    }
}
