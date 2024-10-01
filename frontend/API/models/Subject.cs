namespace API.models;

public record SubjectJSON {
    public required string name { get; init; }
    public bool is_professional { get; init; } = false;
    public ProfessionJSON[] for_professions { get; init; } = [];
    public int grade { get; init; } = 9;
    public int count_per_week { get; init; } = 0;
    public int count_per_year { get; init; } = 0;
}