using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using DynamicData;
using ReactiveUI;
using Splat;
using text_editor.Controls;
using text_editor.Models;
using text_editor.Models.Document;

namespace text_editor.ViewModels
{
    public class HierarchyViewModel : ViewModelBase
    {
        public Context Context { get; set; } = Locator.Current.GetService<Context>(); //Reference to Context's Pages
        public List<MenuItem> MenuItems { get; set; } = new();
        
        public ListBox ListBox;
        public UserControl View;

        public HierarchyViewModel()
        {
            var types = Helpers.Helpers.GetAllMarkdownables();
            foreach(var type in types)
            {
                var item = (IMarkdownable) Activator.CreateInstance(type);
                var menuItem = new MenuItem()
                {
                    Header = item.Name,
                    Command = ReactiveCommand.Create(item.AddToPage)
                };
                MenuItems.Add(menuItem);
            }
        }
    }
}