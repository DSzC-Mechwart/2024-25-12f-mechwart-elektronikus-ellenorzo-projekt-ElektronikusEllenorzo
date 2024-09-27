using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API;

public record APIRequest {
    public required string Endpoint { get; set; }
    public HttpMethod Method { get; set; } = HttpMethod.Get;
    public object? Body { get; set; }
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? Query { get; set; }
}

public class ChalkAPI {
    private static readonly Lazy<ChalkAPI> _instance = new Lazy<ChalkAPI>(() => new ChalkAPI());
    public static ChalkAPI Instance => _instance.Value;

    private readonly HttpClient _httpClient;

    public AuthAPI Auth => new AuthAPI(this);
    public SubjectAPI Subject => new SubjectAPI(this);

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

    private Task<HttpResponseMessage> DoHttpRequest(APIRequest requestParams) {
        var url = $"{Constants.SERVER_URL}/api{requestParams.Endpoint}";
        if (requestParams.Query != null) {
            url = AddQueryParamsToUrl(url, requestParams.Query);
        }

        var req = new HttpRequestMessage(requestParams.Method, url);

        if (requestParams.Headers != null) {
            foreach (var header in requestParams.Headers) {
                req.Headers.Add(header.Key, header.Value);
            }
        }

        if (requestParams.Body != null) {
            var json = JsonConvert.SerializeObject(requestParams.Body);
            req.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var res = _httpClient.SendAsync(req);
        return res;
    }

    public async Task<APIResponse> MakeRequest(APIRequest requestParams) {
        var res = await DoHttpRequest(requestParams);
        return new APIResponse(res);
    }

    public async Task<APIResponse<T>> MakeRequest<T>(APIRequest requestParams) {
        var res = await DoHttpRequest(requestParams);
        return new APIResponse<T>(res);
    }
}

public class APIResponse {
    private readonly HttpResponseMessage HttpResponse;

    public APIResponse(HttpResponseMessage res) {
        this.HttpResponse = res;

        var ms = new MemoryStream();
        res.Content.ReadAsStream().CopyTo(ms);
        Data = JsonConvert.DeserializeObject<JObject>(Encoding.UTF8.GetString(ms.ToArray()));

        Error = Data?.GetValue("error")?.Value<string>();
        if (Error == null && !res.IsSuccessStatusCode) {
            Error = $"Unknown error: {res.StatusCode.ToString()}";
        }
    }

    public HttpStatusCode StatusCode => HttpResponse.StatusCode;
    public HttpResponseHeaders Headers => HttpResponse.Headers;
    public HttpRequestMessage? Request => HttpResponse.RequestMessage;
    public bool Ok => HttpResponse.IsSuccessStatusCode;
    public JObject? Data;
    public string? Error;
}

public class APIResponse<T> : APIResponse {
    public new T? Data;

    public APIResponse(HttpResponseMessage res) : base(res) {
        if (base.Data != null) {
            Data = base.Data.ToObject<T>();
        }
    }
}