using API.models;

namespace API;

public abstract record GetAllSubjectsResponse {
    public SubjectJSON[]? subjects { get; set; }
}

public class SubjectAPI(ChalkAPI chalkApi) {
    public async Task<APIResponse<GetAllSubjectsResponse>> GetAll() {
        var res = await chalkApi.MakeRequest<GetAllSubjectsResponse>(new APIRequest {
            Endpoint = "/subject/all"
        });
        return res;
    }
}