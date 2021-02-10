using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using text_editor.Controls;
using text_editor.Models.Document;

namespace text_editor.Models
{
    //Singleton class
    public class Context : ReactiveObject //Content isnt static because ReactiveUI cant use static classes
    {
        [Reactive] public ObservableCollection<Page> Pages { get; set; } = new () {new Page()};

        public Context()
        {
            Pages[0].Elements.Add(new Text() {TextStr = "Water"});
        }
    }

    namespace Document
    {
        public class Page : ReactiveObject
        {
            [Reactive] public ObservableCollection<IMarkdownable> Elements { get; set; } = new ObservableCollection<IMarkdownable>();
        }
    }
}