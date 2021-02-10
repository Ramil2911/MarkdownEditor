using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using text_editor.Models;

namespace text_editor.Controls
{
    public class Text : ReactiveObject, IMarkdownable
    {
        public string Name => "TextBlock";

        private string _text = "aaaaaaa";

        [Reactive]
        public string TextStr
        {
            get => _text;
            set => _text = value;
        }
        
        public string ToMarkdown()
        {
            return TextStr+"<br/>";
        }
    }
}