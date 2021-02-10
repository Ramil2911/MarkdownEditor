using System;
using System.Reactive;
using ReactiveUI;
using Splat;
using text_editor.Models;

namespace text_editor.Controls
{
    public interface IMarkdownable
    {
        public string ToMarkdown();
        public string Name { get;}
        
        //Adds current IMarkdownable to the document;
        public void AddToPage()
        {
            Locator.Current.GetService<Context>().Pages[0].Elements.Add((IMarkdownable)Activator.CreateInstance(this.GetType()));
        }
    }
}