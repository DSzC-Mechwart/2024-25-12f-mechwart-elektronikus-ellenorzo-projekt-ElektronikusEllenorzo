using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaUtils;

public partial class SimpleNavControl : UserControl {
    private bool hasRegistered = false;

    public static readonly StyledProperty<string> KeyProperty =
        AvaloniaProperty.Register<SimpleNavControl, string>(nameof(Key));

    public string Key {
        get => GetValue(KeyProperty);
        set {
            SetValue(KeyProperty, value);
            if (hasRegistered) return;
            Manager.RegisterNav(
                Key,
                page => ((SimpleNavVM)this.DataContext!).CurrentVM = page,
                DefaultPage
            );
            hasRegistered = true;
        }
    }

    public static readonly StyledProperty<ObservableObject?> DefaultPageProperty =
        AvaloniaProperty.Register<SimpleNavControl, ObservableObject?>(nameof(DefaultPage));

    public ObservableObject? DefaultPage {
        get => GetValue(DefaultPageProperty);
        set {
            SetValue(DefaultPageProperty, value);
            ((SimpleNavVM)this.DataContext!).CurrentVM = DefaultPage;
        }
    }

    public SimpleNavControl() {
        InitializeComponent();
    }
}