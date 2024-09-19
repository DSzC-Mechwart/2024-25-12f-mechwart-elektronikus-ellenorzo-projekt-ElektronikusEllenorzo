using System;
using System.Windows.Input;
using API;
using Chalk.views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chalk.viewmodels;

[AvaUtils.ForView(typeof(LoginView))]
public partial class LoginViewModel : ObservableObject {
    [ObservableProperty]
    private string _username = "";

    [ObservableProperty]
    private string _password = "";

    [ObservableProperty]
    private bool _hasErrored;
    
    [ObservableProperty]
    private string _errorMessage = "";

    public ICommand SubmitCommand => new RelayCommand(async () => {
        var (res, data, error) = await ChalkAPI.Instance.Auth.Login(Username, Password);
        Console.WriteLine($"User data: {data}");
        if (res.IsSuccessStatusCode) {
            AvaUtils.Manager.SetCurrentPage("root", new FrameViewModel());
        }

        HasErrored = !res.IsSuccessStatusCode;
        ErrorMessage = error ?? "";
        
    });
}