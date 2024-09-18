using System.Windows.Input;
using Chalk.views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chalk.viewmodels;

[AvaUtils.ForView(typeof(MainView))]
public partial class MainViewModel : ObservableObject {
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    public ICommand NavigateToHomeCommand => new RelayCommand(() => {
        AvaUtils.Manager.SetCurrentPage("main", new HomeViewModel());
    });
}