using System.Collections.ObjectModel;
using API.models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Chalk.viewmodels;

public partial class SubjectVM(SubjectJSON subject) : ObservableObject {
    [ObservableProperty]
    private string name = subject.name;

    [ObservableProperty]
    private bool isProfessional = subject.is_professional;

    [ObservableProperty]
    private ObservableCollection<ProfessionJSON> forProfessions =
        new(subject.for_professions);

    [ObservableProperty]
    private int grade = subject.grade;

    [ObservableProperty]
    private int countPerWeek = subject.count_per_week;

    [ObservableProperty]
    private int countPerYear = subject.count_per_year;
}