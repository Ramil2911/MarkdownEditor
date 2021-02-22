using System.Collections;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using text_editor.Views;

namespace text_editor.Controls
{
    public abstract class Markdownable : ReactiveObject, IMarkdownable
    {
        public abstract string ToMarkdown();
        public abstract IEnumerable<InspectorElementTemplate> CreateInspectorFields();

        public abstract string Name { get; }
    }
}