using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using text_editor.Controls;
using text_editor.Views;

namespace text_editor.ViewModels
{
    public class InspectorViewModel : ViewModelBase
    {
        public List<InspectorElementTemplate> Elements { get; set; } = new();

        [Reactive] public IMarkdownable CurrentElement { get; set; }
        
        public InspectorViewModel()
        {
            List<InspectorElementTemplate> tempElements = new();
            this
                .WhenAnyValue(x => x.CurrentElement)
                .Skip(1)
                .Subscribe(x =>
                {
                    if (x == null) return;
                    foreach (var propertyInfo in CurrentElement.GetType().GetProperties())
                    {
                        var elementTemplate = new InspectorElementTemplate();
                        elementTemplate.AddTextField(x, propertyInfo);
                        tempElements.Add(elementTemplate);
                    }

                    Elements.Clear();
                    Elements.AddRange(tempElements);
                    tempElements.Clear();
                }, exception => {}); //TODO: Error handling
        }
    }
}