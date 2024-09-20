using API.models;

namespace API;

public class AuthAPI(ChalkAPI chalkApi) {
    public async Task<APIResponse<UserDataJSON>> Login(string username, string password) {
        var res = await chalkApi.MakeRequest<UserDataJSON>(new APIRequest {
            Endpoint = "/auth/login",
            Method = HttpMethod.Post,
            Body = new {
                username, password
            }
        });
        return res;
    }
}