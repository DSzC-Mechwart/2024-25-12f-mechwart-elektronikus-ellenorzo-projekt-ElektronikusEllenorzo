using System;
using Avalonia.Controls;
using Avalonia.Media;

namespace Chalk;

public partial class MainWindow : Window {
    public MainWindow() {
        
        Console.WriteLine(this.PlatformSettings.GetColorValues().AccentColor1.ToString());
        AvaUtils.Manager.accentBrush = new SolidColorBrush(this.PlatformSettings.GetColorValues().AccentColor1);
        InitializeComponent();

    }
}