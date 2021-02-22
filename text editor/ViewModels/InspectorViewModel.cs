using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using text_editor.Controls;
using text_editor.Views;

namespace text_editor.ViewModels
{
    public class InspectorViewModel : ViewModelBase
    {
        [Reactive] public ObservableCollection<InspectorElementTemplate> Elements { get; set; } = new();

        [Reactive] public IMarkdownable CurrentElement { get; set; }
        
        public InspectorViewModel()
        {
            this
                .WhenAnyValue(x => x.CurrentElement)
                .Skip(1)
                .Subscribe(x =>
                {
                    if (x == null) return;
                    Elements.Clear();
                    Elements.AddRange((x as Markdownable).CreateInspectorFields());
                }, exception => { Debug.WriteLine("f");}); //TODO: Error handling
        }
    }
}