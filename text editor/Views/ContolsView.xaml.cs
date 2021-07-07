using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace text_editor.Views
{
    public class ControlsView : UserControl
    {
        public ControlsView()
        {
            InitializeComponent();
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}