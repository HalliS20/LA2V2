using System.Text.Json;
using Gateway.Services.Interfaces;

public class AuthResponse
{
    public string access_token { get; set; }
    public int expires_in { get; set; }
    public string token_type { get; set; }
}



namespace Gateway.Services.Implementations
{
    public class M2MAuthenticationService : IM2MAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public M2MAuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://dev-c16iorpujzhnai1o.us.auth0.com/oauth/token");
        }
        public Task<string> RetrieveAccessToken(string audience)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "client_credentials"},
                    {"client_id", "NwhBUghKqPK6FPTVUqsdSn9JnnppDnW6"},
                    {"client_secret", "GC5WsIZhN06gwEdgYZMjvDAedEaYmg_6XVgleM6B-OSDVW5GiLXC-FoUnT-AsoWQ"},
                    {"audience", audience},
                })
            };
            
            var response = _httpClient.SendAsync(request).Result;
            var jsonPart = response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<AuthResponse>(jsonPart.Result);
            return Task.FromResult(authResponse?.access_token);
        }
    }
}