using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using text_editor.Controls;
using text_editor.ViewModels;
using System.Reflection;
using ReactiveUI;

namespace text_editor.Views
{
    public class InspectorElementTemplate : Panel
    {
        public InspectorElementTemplate()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void AddTextField(IMarkdownable target, PropertyInfo targetField)
        {
            this.FindControl<TextBlock>("FieldName").Text = target.Name;
            
            //TODO: Add type check

            var field = new TextBox();
            field.Watermark = "Write rich text here";

            field
                .WhenAnyValue(x => x.Text)
                .BindTo(target, x => x.GetType().GetProperty(targetField.Name).GetValue(targetField));

            field.Height = 300;
            field.Width = double.NaN;

            this.Children.Add(field);
        }
    }
}