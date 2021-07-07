using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using text_editor.Internationalization.Attributes;

namespace text_editor.Views.Topbars
{
    [LocalizableTopbarName(LOCAL_EN = "Debug", LOCAL_RU = "Отладка", Order = 1)]
    public class DebugTopbarView : TopbarPanelBase
    {
        public DebugTopbarView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}