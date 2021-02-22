using System.Collections.Generic;
using System.Linq;
using DynamicData;
using ReactiveUI.Fody.Helpers;
using text_editor.Attributes;
using text_editor.Views;

namespace text_editor.Controls
{
    public class Text : Markdownable
    {
        public override IEnumerable<InspectorElementTemplate> CreateInspectorFields()
        {
            var properties = this.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(InspectorEditable), true).Length != 0);
            var elements = new List<InspectorElementTemplate>();
            foreach (var property in properties)
            {
                //if (property.GetCustomAttributes(typeof(InspectorEditable), true).Length == 0) continue;
                var elementTemplate = new InspectorElementTemplate();
                elementTemplate.AddTextField(this, this.GetType().GetProperty(nameof(TextStr)));
                elements.Add(elementTemplate);
            }

            return elements;
        }

        public override string Name => "TextBlock";

        [Reactive, InspectorEditable] public string TextStr { get; set; } = "aaaaaaa";

        public override string ToMarkdown()
        {
            return TextStr+"<br/>";
        }
    }
}