using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chalk.viewmodels;

public partial class MainViewModel : ObservableObject {
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    [ObservableProperty]
    private ObservableObject _currentPageModel = null!;

    public ICommand NavigateToHomeCommand => new RelayCommand(() => {
        CurrentPageModel = new HomeViewModel();
    });
}