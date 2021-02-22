using System.Reactive;
using ReactiveUI;

namespace text_editor.Controls
{
    public abstract class Placeholder : ReactiveObject, IMarkdownable
    {
        public abstract string ToMarkdown();

        public abstract string Name { get; }
    }
}