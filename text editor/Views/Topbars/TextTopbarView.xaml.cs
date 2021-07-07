using System.Reactive;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Splat;
using text_editor.Controls;
using text_editor.Internationalization.Attributes;
using text_editor.Models;

namespace text_editor.Views.Topbars
{
    [LocalizableTopbarName(LOCAL_EN = "Text", LOCAL_RU = "Текст", Order = 0)]
    public class TextTopbarView : TopbarPanelBase
    {
        public TextTopbarView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void AddText(object? sender, RoutedEventArgs e)
        {
            Locator.Current.GetService<Context>().Pages[0].Elements.Add(new Text());
        }

        private void AddHorizontalRule(object? sender, RoutedEventArgs e)
        {
            Locator.Current.GetService<Context>().Pages[0].Elements.Add(new HorizontalRule());
        }
    }
}