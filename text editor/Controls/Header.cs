using System.Collections.Generic;
using ReactiveUI.Fody.Helpers;
using text_editor.Attributes;
using text_editor.Views;

namespace text_editor.Controls
{
    public class Header : Markdownable
    {
        public override string ToMarkdown()
        {
            return (new string('#', Level) + ' ' + Text);
        }

        public override string Name { get; } = "Header";

        [Reactive, InspectorEditable] public ushort Level { get; set; } = 1;
        [Reactive, InspectorEditable] public string Text { get; set; } = "";

        public override IEnumerable<InspectorElementTemplate> CreateInspectorFields()
        {
            var elements = new List<InspectorElementTemplate>();

            //Add Level template
            var headerLevelTemplate = new InspectorElementTemplate();
            headerLevelTemplate.AddIntField(this, this.GetType().GetProperty(nameof(Level)));
            elements.Add(headerLevelTemplate);
            
            //Add Text template
            var headerTextTemplate = new InspectorElementTemplate();
            headerTextTemplate.AddTextField(this, this.GetType().GetProperty(nameof(Text)));
            elements.Add(headerTextTemplate);

            return elements;
        }
    }
}