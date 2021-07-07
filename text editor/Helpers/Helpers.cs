using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static Type[] GetChildren<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                // ReSharper disable once CheckForReferenceEqualityInstead.4
                // ReSharper disable once CheckForReferenceEqualityInstead.2
                // reference equality gives different result
                .Where(x => x.IsSubclassOf(typeof(T)) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x)
                .ToArray();
        }
        
        public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}