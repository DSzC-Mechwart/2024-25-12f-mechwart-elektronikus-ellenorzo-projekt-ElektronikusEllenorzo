using System.Net;

namespace API;

public class ChalkAPI {
    private static readonly Lazy<ChalkAPI> _instance = new Lazy<ChalkAPI>(() => new ChalkAPI());
    public static ChalkAPI Instance => _instance.Value;

    private readonly HttpClient _httpClient;

    private ChalkAPI() {
        var handler = new HttpClientHandler() {
            CookieContainer = new CookieContainer()
        };
        _httpClient = new HttpClient(handler);
    }

    public async Task<bool> Login(string username, string password) {
        var formData = new FormUrlEncodedContent([
            new("username", username),
            new("password", password)
        ]);
        var res = await _httpClient.PostAsync($"{Constants.SERVER_URL}/api/auth/login", formData);
        return res.IsSuccessStatusCode;
    }
}