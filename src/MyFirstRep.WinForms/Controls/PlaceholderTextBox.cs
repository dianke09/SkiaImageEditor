namespace MyFirstRep.WinForms.Controls;

public sealed class PlaceholderTextBox : TextBox
{
    private string _placeholderText = "请输入内容...";
    private Color _placeholderColor = Color.Gray;
    private bool _isPlaceholderActive;

    public string PlaceholderTextEx
    {
        get => _placeholderText;
        set
        {
            _placeholderText = value;
            ShowPlaceholderIfNeeded();
        }
    }

    public Color PlaceholderColor
    {
        get => _placeholderColor;
        set
        {
            _placeholderColor = value;
            if (_isPlaceholderActive)
            {
                ForeColor = _placeholderColor;
            }
        }
    }

    public PlaceholderTextBox()
    {
        GotFocus += (_, _) => RemovePlaceholder();
        LostFocus += (_, _) => ShowPlaceholderIfNeeded();
        ShowPlaceholderIfNeeded();
    }

    public string RealText => _isPlaceholderActive ? string.Empty : Text;

    private void ShowPlaceholderIfNeeded()
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            return;
        }

        _isPlaceholderActive = true;
        Text = _placeholderText;
        ForeColor = _placeholderColor;
    }

    private void RemovePlaceholder()
    {
        if (!_isPlaceholderActive)
        {
            return;
        }

        _isPlaceholderActive = false;
        Text = string.Empty;
        ForeColor = SystemColors.WindowText;
    }
}
