namespace API.models;

public record UserDataJSON {
    public int id { get; init; }
    public int for_user { get; init; }
    public string role { get; init; } = "";
    public string name { get; init; } = "";
    public int? student_class { get; init; }
    public string? mothers_name { get; init; } = "";
    public string? place_of_birth { get; init; } = "";
    public string? date_of_birth { get; init; } = "";
    public string? address { get; init; } = "";
    public int? profession { get; init; }
    public string? dorm_name { get; init; }
    public bool is_first_login { get; init; }
    public int[]? subjects { get; init; } = [];
}