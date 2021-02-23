using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using text_editor.Controls;
using System.Reflection;
using ReactiveUI;

namespace text_editor.Views
{
    public class InspectorElementTemplate : Panel
    {
        private bool _fieldInititalized = false;
        
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
            if (_fieldInititalized) throw new Exception("Template already initialized;");
            this.FindControl<TextBlock>("FieldName").Text = target.Name;
            
            //TODO: Add type check

            var field = new TextBox
            {
                Watermark = "Write rich text here",
                Text = targetField.GetValue(target) as string
            };

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
            _fieldInititalized = true;
        }
        
        public void AddIntField(IMarkdownable target, PropertyInfo targetField)
        {
            if (_fieldInititalized) throw new Exception("Template already initialized;");
            this.FindControl<TextBlock>("FieldName").Text = target.Name;
            
            //TODO: Add type check

            var field = new NumericUpDown()
            {
                Value = Convert.ToDouble(targetField.GetValue(target)),
                Increment = 1,
                Minimum = 1,
                Maximum = 6,
            }; //TODO: make it not only-header-compatible

            field
                .WhenAnyValue(x => x.Value)
                .Subscribe(x =>
                {
                    var a = (ushort) x;
                    //target.GetType().GetProperty(targetField.Name).GetSetMethod().Invoke(target, new object?[]{x});
                    target.GetType().GetProperty(targetField.Name).GetSetMethod().Invoke(target, new object?[] {a});
                    //я не нашел, как подружить ReactiveUI Bind с рефлексией, придется писать значение переменной в инспектор во время *здесь*, а потом вызывать set-свойство
                });

            field.Height = 40;
            field.Width = double.NaN;

            this.Children.Add(field);
            Debug.WriteLine("a");
            _fieldInititalized = true;
        }
    }
}