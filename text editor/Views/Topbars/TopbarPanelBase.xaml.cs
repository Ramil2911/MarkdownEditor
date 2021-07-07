using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using text_editor.Internationalization.Attributes;

namespace text_editor.Views.Topbars
{
    [LocalizableTopbarName(LOCAL_EN = "ERR_NO_LOCAL", LOCAL_RU = "ERR_NO_LOCAL", Order = int.MaxValue)]
    public abstract class TopbarPanelBase : UserControl
    {
        public TopbarPanelBase()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}