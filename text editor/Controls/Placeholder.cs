using System.Reactive;
using ReactiveUI;

namespace text_editor.Controls
{
    public class Placeholder : ReactiveObject, IMarkdownable
    {
        public string ToMarkdown()
        {
            return "";
        }

        public string Name { get; } = "Placeholder";
    }
}