using System.Net.Http;
using LolChallenges.Server.Interfaces.Repositories;

namespace LolChallenges.Server.Repositories
{
    public class RiotRepository : IRiotRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public RiotRepository(IConfiguration config, HttpClient httpClient)
        {
            _apiKey = config["RiotApiKey"];
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> HandleRequestAsync(string endpointSuffix)
        {
            HttpRequestMessage request = new(HttpMethod.Get, endpointSuffix);
            request.Headers.Add("X-Riot-Token", _apiKey);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode) throw new BadHttpRequestException(response.ReasonPhrase ?? "Unknown Failure", (int)response.StatusCode);

            return response;
        }
    }
}
