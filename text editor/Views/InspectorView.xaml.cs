using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using text_editor.Controls;
using text_editor.Helpers;
using text_editor.ViewModels;

namespace text_editor.Views
{
    public class InspectorView : UserControl
    {

        public InspectorView()
        {
            ViewReferences.InspectorView = this;
            DataContext = new InspectorViewModel();
            InitializeComponent();

            
            var children = this.FindControl<StackPanel>("Panel").Children;
            Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => (DataContext as InspectorViewModel).Elements.CollectionChanged += handler, 
                handler => (DataContext as InspectorViewModel).Elements.CollectionChanged -= handler)
                .Subscribe(x =>
                {
                    children.Clear();
                    children.AddRange((ObservableCollection<InspectorElementTemplate>)x.Sender);
                });


            ViewReferences
                .DocList
                .FindControl<Grid>("Grid")
                .FindControl<ListBox>("DocList")
                .Events()
                .SelectionChanged
                .Subscribe(x =>
                {
                    if (x.AddedItems[0] != null)
                    {
                        ((InspectorViewModel) DataContext).CurrentElement = (IMarkdownable) x.AddedItems[0];
                    }
                });
            //Looks like it wont work
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}