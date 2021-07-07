
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Splat;
using text_editor.Models;
using System.Reactive.Linq;
using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.Html;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.VisualTree;
using ReactiveUI.Fody.Helpers;
using text_editor.Controls;
using text_editor.Helpers;
using text_editor.ViewModels;

namespace text_editor.Views
{
    public class PreviewerContainer : UserControl
    {
        
        public static readonly StyledProperty<IMarkdownable> MarkdownContextProperty =
            AvaloniaProperty.Register<PreviewerContainer, IMarkdownable>(nameof(MarkdownContext));

        public IMarkdownable MarkdownContext
        {
            get => GetValue(MarkdownContextProperty);
            set => SetValue(MarkdownContextProperty, value);
        }
        
        [Reactive]
        public bool IsRedactor { get; set; } = false;

        public PreviewerContainer()
        {
            InitializeComponent();
            var htmlLabel = new HtmlLabel()
            {
                AutoSize = true,
                AutoSizeHeightOnly = true,
                AvoidImagesLateLoading = true,
                Width = double.NaN,
                Text = MarkdownContext.ToMarkdown(),
            };
            this.LogicalChildren.Add(htmlLabel);

            this.WhenAnyValue(x => x.IsRedactor)
                .Subscribe(x =>
                {
                    if (IsRedactor)
                    {
                        LogicalChildren.Clear();
                        //so...
                    }
                    else
                    {
                        LogicalChildren.Clear();
                        var htmlLabel = new HtmlLabel
                        {
                            AutoSize = true,
                            AutoSizeHeightOnly = true,
                            AvoidImagesLateLoading = true,
                            Text = MarkdownContext.ToMarkdown(),
                            Width = double.NaN
                        };
                        LogicalChildren.Add(htmlLabel);
                    }
                });
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        
    }
}