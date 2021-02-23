using System.Collections.Generic;
using text_editor.Views;

namespace text_editor.Controls
{
    public class HorizontalRule : Markdownable
    {
        public override string ToMarkdown()
        {
            return "***";
        }

        public override string Name { get; } = "Horizontal Rule";

        public override IEnumerable<InspectorElementTemplate> CreateInspectorFields()
        {
            return new List<InspectorElementTemplate>();
        }
    }
}