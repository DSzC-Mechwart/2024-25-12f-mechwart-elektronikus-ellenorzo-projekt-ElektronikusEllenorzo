using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaUtils;

public partial class SimpleNavVM : ObservableObject {
    [ObservableProperty]
    private ObservableObject? _currentVM;
}