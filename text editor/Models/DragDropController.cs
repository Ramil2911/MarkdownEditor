using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using DynamicData;
using ReactiveUI;
using text_editor.Controls;
using text_editor.Helpers;
using text_editor.Views;

namespace text_editor.Models
{
    //Sigleton class
    public class DragDropController
    {
        //Target is item that is clicked by mouse, all calculations are relative to it
        // public DragDropPanel DraggingPanelTarget { get; set; }
        //
        // public void SetTarget(DragDropPanel panel)
        // {
        //     DraggingPanelTarget = panel;
        // }
        // public void DeleteTarget(DragDropPanel panel)
        // {
        //     if (ReferenceEquals(panel, DraggingPanelTarget)) DraggingPanelTarget = panel;
        // }
        
        public void PointerOverIt(DragDropPanel it, PointerEventArgs eventArgs)
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