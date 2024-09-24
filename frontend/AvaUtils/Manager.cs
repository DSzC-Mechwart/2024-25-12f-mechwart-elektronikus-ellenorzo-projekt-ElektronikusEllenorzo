using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaUtils;

public static class Manager {
    private static readonly Dictionary<string, Action<ObservableObject>> _navSetters = new();
    private static readonly Dictionary<string, Optional<ObservableObject>> _navCurrentPages = new();

    public static Brush accentBrush = new SolidColorBrush(Color.Parse("#026fc7"));

    public static void RegisterNav(string key, Action<ObservableObject> setter, ObservableObject? currentPage) {
        _navSetters[key] = setter;
        if (currentPage != null) _navCurrentPages[key] = currentPage;
    }

    public static void SetCurrentPage(string key, ObservableObject currentPage) {
        if (!_navSetters.TryGetValue(key, out var setter)) return;
        setter.Invoke(currentPage);
        _navCurrentPages[key] = currentPage;
    }

    public static Optional<ObservableObject> GetCurrentPage(string key) {
        return _navCurrentPages.TryGetValue(key, out var page) ? page : Optional<ObservableObject>.Empty;
    }
}