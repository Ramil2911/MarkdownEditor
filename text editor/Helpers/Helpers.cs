using System;
using System.Collections.Generic;
using System.Linq;
using text_editor.Controls;

namespace text_editor.Helpers
{
    public static class Helpers
    {
        public static IEnumerable<Type> GetAllMarkdownables()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IMarkdownable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x);
        }
        
        public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}