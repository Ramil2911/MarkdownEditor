using System.Reactive.Linq;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using DynamicData;
using DynamicData.Binding;
using Markdig;
using Markdig.Renderers;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using text_editor.Controls;
using text_editor.Models;
using text_editor.Models.Document;

namespace text_editor.ViewModels
{
    public class PreviewViewModel : ViewModelBase
    {
        [Reactive]
        public string Html { get; set; } = "";

        public PreviewViewModel()
        {
            var pipeline = new Markdig.MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            
            var context = Locator.Current.GetService<Context>();
            string raw = "";
            foreach (var item in context.Pages[0].Elements)
            {
                raw += item.ToMarkdown();
                raw += "\n";
            }
            
            Html = Markdown.ToHtml(raw, pipeline);

            context.Pages[0].Elements
                .ToObservableChangeSet()
                .AutoRefresh()
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Subscribe(x =>
                {
                    string raw = "";
                    foreach (var item in context.Pages[0].Elements)
                    {
                        raw += item.ToMarkdown();
                        raw += "\n";
                    }
                    Html = Markdown.ToHtml(raw, pipeline);
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