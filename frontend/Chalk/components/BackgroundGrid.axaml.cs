using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Chalk.components;

public partial class BackgroundGrid : UserControl {
    public BackgroundGrid() {
        InitializeComponent();
    }

    public double GridSize { get; set; } = 20.0;
    public double OffsetX { get; set; }
    public double OffsetY { get; set; }
    public IBrush GridLineBrush { get; set; } = Brushes.LightGray;

    public override void Render(DrawingContext context) {
        base.Render(context);

        var bounds = new Rect(0, 0, Bounds.Width, Bounds.Height);

        for (double x = 0; x < bounds.Width; x += GridSize) {
            context.DrawLine(new Pen(GridLineBrush), new Point(x + OffsetX, 0), new Point(x + OffsetX, bounds.Height));
        }

        for (double y = 0; y < bounds.Height; y += GridSize) {
            context.DrawLine(new Pen(GridLineBrush), new Point(0, y + OffsetY), new Point(bounds.Width, y + OffsetY));
        }
    }
}