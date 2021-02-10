using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using DynamicData;
using text_editor.Controls;
using text_editor.Models;

namespace text_editor.Views
{
    public class DragDropPanel : Panel
    {
        public static readonly StyledProperty<IMarkdownable> ContextReferenceProperty =
            AvaloniaProperty.Register<DragDropPanel, IMarkdownable>(nameof(ContextReference));

        public IMarkdownable ContextReference
        {
            get => GetValue(ContextReferenceProperty);
            set => SetValue(ContextReferenceProperty, value);
        }
        
        
        public DragDropPanel()
        {
            var controller = (DragDropController)Splat.Locator.Current.GetService(typeof(DragDropController));
            
            InitializeComponent();
            //Doesnt work
            // this.Events()
            //     .PointerPressed
            //     .Subscribe(x =>
            //     {
            //         controller.SetTarget(this);
            //     });
            //Obsolete because of avalonia update
            // this.Events()
            //     .PointerEnter
            //     .Subscribe(x =>
            //     {
            //         controller.PointerOverIt(this, x);
            //     });
            this.Events()
                .PointerReleased
                .Subscribe(x =>
                {
                    PointerOverIt(this, x);
                });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        //Moved from dragdropcontroller
        private static void PointerOverIt(DragDropPanel it, PointerEventArgs eventArgs)
        {
            System.Diagnostics.Debug.WriteLine("DragDropEvent");
            var listBox = it.Parent.Parent as ListBox;
            if(listBox.SelectedItems.Count == 0) return;


            it = listBox.GetVisualsAt(eventArgs.GetPosition(listBox)).ToList()[0].VisualParent as DragDropPanel;
            if(it == null) return;
            System.Diagnostics.Debug.WriteLine(it.ContextReference.Name);

            ;
            
            // if(DraggingPanelTarget == null | it == null) return;
            // if(ReferenceEquals(DraggingPanelTarget, it)) return;
            // if(!ReferenceEquals(DraggingPanelTarget.Parent.Parent, it.Parent.Parent)) return;
            var document = ((Context) Splat.Locator.Current.GetService(typeof(Context))).Pages[0].Elements;
            if (listBox.Selection.SelectedIndexes.Any(index => ReferenceEquals(document[index], it.ContextReference))) return;

            var copy = document.ToList();
            var selected = new List<IMarkdownable>();
            
            foreach (var item in listBox.Selection.SelectedIndexes)
            {
                selected.Add(document[item]);
                copy.Remove(document[item]);
            }

            copy.InsertRange(document.IndexOf(it.ContextReference),  selected);
            document.Clear();
            document.Add(copy);
        }
    }
}