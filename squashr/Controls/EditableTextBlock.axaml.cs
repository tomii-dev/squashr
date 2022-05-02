using Avalonia.Controls;
using Avalonia;
using System;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace squashr.Controls
{
    public partial class EditableTextBlock : UserControl
    {
        private Border _border;
        private TextBlock _block;
        private string _text;
        private int _fontSize;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                _block.Text = value;
            }
        }

        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                _block.FontSize = value;
            }
        }
        public EditableTextBlock()
        {
            InitializeComponent();
            _border = this.Find<Border>("Border");
            _block = this.Find<TextBlock>("Block");
            _border.BorderThickness = Thickness.Parse("0");
            PointerEnter += (o, e) => Cursor = new Cursor(StandardCursorType.Ibeam);
            PointerPressed += OnPointerPressed;
            TextInput += (o, e) => Text += e.Text;
            KeyDown += OnKeyDown;
        }

        private void OnPointerPressed(object o, PointerEventArgs e)
        {
            Focus();
            _border.BorderThickness = Thickness.Parse("1");
        }

        private void OnKeyDown(object o, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (_text.Length == 0) return;
                Text = _text.Remove(_text.Length - 1);
            }
            if(e.Key == Key.Enter)
            {
                FocusManager.Instance.Focus(null);
                _border.BorderThickness = Thickness.Parse("0");
            }
        }
    }
}

