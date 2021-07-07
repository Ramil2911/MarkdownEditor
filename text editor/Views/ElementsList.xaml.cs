
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Splat;
using text_editor.Models;
using System.Reactive.Linq;
using System;
using System.Linq;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.VisualTree;
using text_editor.Controls;
using text_editor.Helpers;
using text_editor.ViewModels;

namespace text_editor.Views
{
    public class ElementsList : UserControl
    {

        public ElementsList()
        {
            ViewReferences.DocList = this;
            DataContext = new HierarchyViewModel();
            InitializeComponent();
            
            //Add ListBox bindings;
            ((HierarchyViewModel)DataContext).ListBox = this.FindControl<ListBox>("DocList");
            ((HierarchyViewModel)DataContext).View = this;
            Locator.Current.GetService<Context>()
                .WhenAnyValue(x => x.Pages[0].Elements)
                .BindTo(this.FindControl<ListBox>("DocList"), x => x.Items);
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}