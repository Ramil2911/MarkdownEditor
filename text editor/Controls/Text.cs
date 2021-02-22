using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using text_editor.Attributes;
using text_editor.Models;

namespace text_editor.Controls
{
    public class Text : Placeholder
    {
        public override string Name => "TextBlock";

        [Reactive, InspectorEditable] public string TextStr { get; set; } = "aaaaaaa";

        public override string ToMarkdown()
        {
            return TextStr+"<br/>";
        }
    }
}