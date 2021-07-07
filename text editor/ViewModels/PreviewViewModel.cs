using System.Reactive.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Avalonia.Controls;
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
        public ObservableCollection<Markdownable> Elements { get; set; }

        public PreviewViewModel()
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            
            var context = Locator.Current.GetService<Context>();
            Elements = context.Pages[0].Elements;
            /*string raw = "";
            context.Pages[0].Elements
                .ToObservableChangeSet()
                .AutoRefresh()
                .Throttle(TimeSpan.FromMilliseconds(20))
                .Subscribe(x =>
                {
                    
                });*/

        }
    }
}