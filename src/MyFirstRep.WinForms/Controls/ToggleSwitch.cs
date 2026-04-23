using System.Drawing.Drawing2D;

namespace MyFirstRep.WinForms.Controls;

public sealed class ToggleSwitch : CheckBox
{
    public Color OnBackColor { get; set; } = Color.SeaGreen;
    public Color OffBackColor { get; set; } = Color.DarkGray;
    public Color ToggleColor { get; set; } = Color.WhiteSmoke;

    public ToggleSwitch()
    {
        MinimumSize = new Size(45, 22);
        AutoSize = false;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        pevent.Graphics.Clear(Parent?.BackColor ?? Color.White);

        var toggleSize = Height - 5;
        var rect = new Rectangle(0, 0, Width - 1, Height - 1);

        using var backPath = GetRoundedRectPath(rect, Height / 2);
        using var onBrush = new SolidBrush(Checked ? OnBackColor : OffBackColor);
        pevent.Graphics.FillPath(onBrush, backPath);

        var toggleRect = Checked
            ? new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize)
            : new Rectangle(2, 2, toggleSize, toggleSize);

        using var toggleBrush = new SolidBrush(ToggleColor);
        pevent.Graphics.FillEllipse(toggleBrush, toggleRect);
    }

    private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        var curve = radius * 2;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curve, curve, 180, 90);
        path.AddArc(rect.Right - curve, rect.Y, curve, curve, 270, 90);
        path.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curve, curve, curve, 90, 90);
        path.CloseFigure();
        return path;
    }
}
