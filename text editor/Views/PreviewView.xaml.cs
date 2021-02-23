using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using text_editor.ViewModels;
using WebViewControl;

namespace text_editor.Views
{
    public class PreviewView : UserControl
    {
        private string css = @"";
        
        public PreviewView()
        {
            DataContext = new PreviewViewModel();
            InitializeComponent();
            var webView = this.FindControl<WebView>("WebView");
            webView.IsHistoryDisabled = true;
#if DEBUG
            webView.AllowDeveloperTools = true;
#endif
            webView.DisableBuiltinContextMenus = true;
            (DataContext as PreviewViewModel)
                .WhenAnyValue(x => x.Html)
                .Subscribe(x =>
                {
                    webView.LoadHtml(x);
                    System.Diagnostics.Debug.WriteLine(x);
                });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}