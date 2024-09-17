using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Chalk;

public class ViewLocator : IDataTemplate {
    public Control? Build(object? data) {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("viewmodels", "views", StringComparison.Ordinal);
        name = name.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);
        

        if (type != null) {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data) {
        return data is ObservableObject;
    }
}