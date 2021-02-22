using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using text_editor.Attributes;
using text_editor.Controls;
using text_editor.Models;
using text_editor.Views;

namespace text_editor.ViewModels
{
    public class InspectorViewModel : ViewModelBase
    {
        [Reactive] public ObservableCollection<InspectorElementTemplate> Elements { get; set; } = new();

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
                        if (propertyInfo.GetCustomAttributes(typeof(InspectorEditable), true).Length == 0) continue;
                        var elementTemplate = new InspectorElementTemplate();
                        elementTemplate.AddTextField(x, propertyInfo);
                        tempElements.Add(elementTemplate);
                    }

                    Elements.Clear();
                    Elements.AddRange(tempElements);
                    tempElements.Clear();
                }, exception => { Debug.WriteLine("f");}); //TODO: Error handling
        }
    }
}