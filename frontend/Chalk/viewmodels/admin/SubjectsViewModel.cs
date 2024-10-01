using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using API;
using API.models;
using Chalk.views;
using Chalk.views.admin;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chalk.viewmodels.admin;

[AvaUtils.ForView(typeof(SubjectsView))]
public partial class SubjectsViewModel : ObservableObject {
    [ObservableProperty]
    private ObservableCollection<SubjectVM> allSubjects = [];

    public SubjectsViewModel() {
        Task.Run(async () => {
            var res = await ChalkAPI.Instance.Subject.GetAll();
            res.Data?.subjects?.Select(x => new SubjectVM(x)).ToList().ForEach(allSubjects.Add);
        });
    }
}