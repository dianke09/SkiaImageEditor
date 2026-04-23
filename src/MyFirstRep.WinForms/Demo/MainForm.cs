using MyFirstRep.WinForms.Controls;

namespace MyFirstRep.WinForms.Demo;

public sealed class MainForm : Form
{
    public MainForm()
    {
        Text = "myfirstrep 控件 WinForms(.NET 10) 改写示例";
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(600, 360);

        var title = new Label
        {
            Text = "控件演示",
            Font = new Font("Microsoft YaHei", 16, FontStyle.Bold),
            Location = new Point(24, 20),
            AutoSize = true
        };

        var roundedButton = new RoundedButton
        {
            Text = "提交",
            Location = new Point(24, 80),
            FillColor = Color.FromArgb(57, 127, 243)
        };

        var placeholderTextBox = new PlaceholderTextBox
        {
            PlaceholderTextEx = "请输入用户名",
            Location = new Point(24, 140),
            Width = 220
        };

        var toggleLabel = new Label
        {
            Text = "启用功能",
            Location = new Point(24, 190),
            AutoSize = true
        };

        var toggleSwitch = new ToggleSwitch
        {
            Location = new Point(110, 184),
            Checked = true
        };

        Controls.Add(title);
        Controls.Add(roundedButton);
        Controls.Add(placeholderTextBox);
        Controls.Add(toggleLabel);
        Controls.Add(toggleSwitch);
    }
}
