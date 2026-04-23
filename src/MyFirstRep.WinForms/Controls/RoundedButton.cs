using System.Drawing.Drawing2D;

namespace MyFirstRep.WinForms.Controls;

public sealed class RoundedButton : Button
{
    private int _cornerRadius = 14;

    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = Math.Max(2, value);
            Invalidate();
        }
    }

    public Color FillColor { get; set; } = Color.FromArgb(30, 144, 255);
    public Color BorderColor { get; set; } = Color.FromArgb(25, 25, 112);
    public int BorderSize { get; set; } = 1;

    public RoundedButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.White;
        Size = new Size(140, 40);
        Cursor = Cursors.Hand;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using var path = CreateRoundedPath(ClientRectangle, CornerRadius);
        using var fillBrush = new SolidBrush(FillColor);
        using var borderPen = new Pen(BorderColor, BorderSize);

        pevent.Graphics.FillPath(fillBrush, path);
        if (BorderSize > 0)
        {
            pevent.Graphics.DrawPath(borderPen, path);
        }

        TextRenderer.DrawText(
            pevent.Graphics,
            Text,
            Font,
            ClientRectangle,
            ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private static GraphicsPath CreateRoundedPath(Rectangle rect, int radius)
    {
        var diameter = radius * 2;
        var arc = new Rectangle(rect.Location, new Size(diameter, diameter));
        var path = new GraphicsPath();

        path.AddArc(arc, 180, 90);
        arc.X = rect.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = rect.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();

        return path;
    }
}
