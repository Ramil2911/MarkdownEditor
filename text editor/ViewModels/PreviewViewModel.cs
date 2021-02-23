using System.Reactive.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using DynamicData;
using DynamicData.Binding;
using Markdig;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using text_editor.Controls;
using text_editor.Models;

namespace text_editor.ViewModels
{
    public class PreviewViewModel : ViewModelBase
    {
        //В DragDropPanel находится логика перемещения объектов, но .Add(), вызываемый 1 раз, вызывает изменение ObservableCollection .Count()+1 раз
        
        
        [Reactive]
        public string Html { get; set; } = "";
        
        public PreviewViewModel()
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            
            var context = Locator.Current.GetService<Context>();
            string raw = "";
            context.Pages[0].Elements
                .ToObservableChangeSet()
                .AutoRefresh()
                .Throttle(TimeSpan.FromMilliseconds(20))
                .Subscribe(x =>
                {
                    string raw = "";
                    foreach (var item in context.Pages[0].Elements)
                    {
                        raw += item.ToMarkdown();
                        raw += "\n";
                    }
                    Html =
                        $"<!DOCTYPE html>\n<html>\n<head>\n<style>\n@font-face {{\n font-family: \"Roboto\";\n src: local(\"/fonts/Lato-Black.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-BlackItalic.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-Bold.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-BoldItalic.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-Italic.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-Licht.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-LightItalic.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-Regular.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-Thin.ttf\") format(\"truetype\"),\n local(\"/fonts/Roboto-ThinItalic.ttf\") format(\"truetype\"),\n}}\nbody {{ font-family: 'Lato', sans-serif; }}\n</style>\n</head>\n<body>{Markdown.ToHtml(raw, pipeline)}\n</body>\n</html>";
                });


            /*Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                    handler => context.Pages[0].Elements.CollectionChanged += handler, 
                    handler => context.Pages[0].Elements.CollectionChanged -= handler)
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Subscribe(x =>
                {
                    string raw = "";
                    foreach (var item in (ObservableCollection<IMarkdownable>) x.Sender)
                    {
                        raw += item.ToMarkdown();
                    }

                    Html = Markdown.ToHtml(raw);
                });*/
        }
    }
}