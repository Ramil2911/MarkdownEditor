using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using text_editor.ViewModels;

namespace text_editor.Views
{
    public class PreviewView : UserControl
    {

        public PreviewView()
        {
            DataContext = new PreviewViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}