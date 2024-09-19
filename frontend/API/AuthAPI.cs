namespace API;

public class AuthAPI(ChalkAPI chalkApi) {
    public async Task<(HttpResponseMessage, dynamic?, string?)> Login(string username, string password) {
        var res = await chalkApi.MakeRequest(
            endpoint: "/auth/login",
            method: HttpMethod.Post,
            body: new {
                username, password
            }
        );
        return res;
    }
}