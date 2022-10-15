using ChatApplication.Services.Abstractions;
using System.Net.Http.Json;

namespace ChatApplication.Services
{
    public class ChatService : IChatService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<T>> GetAllAsync<T>(string route)
        {
            var httpClient = _httpClientFactory.CreateClient("TalkApi");
            var result = await httpClient.GetAsync(route);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<IList<T>>();
        }

        public async Task<T> CreateAsync<T>(T request, string route)
        {
            var httpClient = _httpClientFactory.CreateClient("TalkApi");
            var result = await httpClient.PostAsJsonAsync(route, request);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsAsync<T>();
        }
    }
}
