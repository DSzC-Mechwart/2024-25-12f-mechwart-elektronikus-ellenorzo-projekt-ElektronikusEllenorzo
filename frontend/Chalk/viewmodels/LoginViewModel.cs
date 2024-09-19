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

    public ICommand SubmitCommand => new RelayCommand(async () => {
        var success = await ChalkAPI.Instance.Login(Username, Password);
        if (success) {
            AvaUtils.Manager.SetCurrentPage("root", new FrameViewModel());
        }

        HasErrored = !success;
    });
}