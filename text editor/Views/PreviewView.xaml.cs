using System.Reactive.Linq;
using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using ReactiveUI;
using text_editor.ViewModels;
using WebViewControl;

namespace text_editor.Views
{
    public class PreviewView : UserControl
    {
        private ListBox _listBox;
        
        public PreviewView()
        {
            DataContext = new PreviewViewModel();
            InitializeComponent();
            var webView = this.FindControl<WebView>("WebView");
            (DataContext as PreviewViewModel)
                .WhenAnyValue(x => x.Html)
                .Subscribe(x =>
                {
                    webView.LoadHtml(x);
                    System.Diagnostics.Debug.WriteLine(x);
                });

            _listBox = this.FindControl<ListBox>("DocList");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}