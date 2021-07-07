using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using text_editor.ViewModels;

namespace text_editor.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new MainWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}