using System.Net;
using System.Text;
using System.Text.Json;

namespace API;

public class ChalkAPI {
    private static readonly Lazy<ChalkAPI> _instance = new Lazy<ChalkAPI>(() => new ChalkAPI());
    public static ChalkAPI Instance => _instance.Value;

    private readonly HttpClient _httpClient;

    public AuthAPI Auth => new AuthAPI(this);

    private ChalkAPI() {
        var handler = new HttpClientHandler() {
            CookieContainer = new CookieContainer()
        };
        _httpClient = new HttpClient(handler);
    }

    private static string AddQueryParamsToUrl(string url, Dictionary<string, string> queryParams) {
        var query = new StringBuilder(url.Contains('?') ? "&" : "?");

        foreach (var param in queryParams) {
            query.Append($"{Uri.EscapeDataString(param.Key)}={Uri.EscapeDataString(param.Value)}&");
        }

        return url + query.ToString().TrimEnd('&', '?');
    }

    public async Task<(HttpResponseMessage res, object? data, string? error)> MakeRequest(
        string endpoint,
        HttpMethod? method = null,
        object? body = null,
        Dictionary<string, string>? headers = null,
        Dictionary<string, string>? query = null
    ) {
        method ??= HttpMethod.Get;

        var url = $"{Constants.SERVER_URL}/api{endpoint}";
        if (query != null) {
            url = AddQueryParamsToUrl(url, query);
        }

        var req = new HttpRequestMessage(method, url);

        if (headers != null) {
            foreach (var header in headers) {
                req.Headers.Add(header.Key, header.Value);
            }
        }

        if (body != null) {
            var json = JsonSerializer.Serialize(body);
            req.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var res = await _httpClient.SendAsync(req);
        var content = await res.Content.ReadAsStringAsync();
        var data = JsonDocument.Parse(content).RootElement;
        string? error = data.TryGetProperty("error", out var _error) ? _error.GetString() : null;
        if (error == null && !res.IsSuccessStatusCode) {
            error = $"Unknown error: {res.StatusCode.ToString()}";
        }

        return (res, data.Deserialize<dynamic>(), error);
    }
}