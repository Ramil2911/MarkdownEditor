using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using text_editor.Controls;
using text_editor.ViewModels;
using System.Reflection;
using ReactiveUI;
using System.Reactive;

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
            field.Text = targetField.GetValue(target) as string;
            
            field
                .WhenAnyValue(x => x.Text)
                .Subscribe(x =>
                    {
                        //target.GetType().GetProperty(targetField.Name).GetSetMethod().Invoke(target, new object?[]{x});
                        target.GetType().GetProperty(targetField.Name).GetSetMethod().Invoke(target, new object?[] {x});
                        //я не нашел, как подружить ReactiveUI Bind с рефлексией, придется писать значение переменной в инспектор во время *здесь*, а потом вызывать set-свойство
                    });

            field.Height = 300;
            field.Width = double.NaN;

            this.Children.Add(field);
            Debug.WriteLine("a");
        }
    }
}