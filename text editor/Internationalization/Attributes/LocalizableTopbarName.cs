using System;
using System.Globalization;
using Svg;
using text_editor.Views.Topbars;

namespace text_editor.Internationalization.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LocalizableTopbarName : Attribute, ILocalizable
    {
        public int Order { get; init; }
        public string LOCAL_RU { get; init; }
        public string LOCAL_EN { get; init; }

        public string LocalizedString =>
            CultureInfo.InstalledUICulture.TwoLetterISOLanguageName switch
            {
                "ru" => LOCAL_RU,
                _ => LOCAL_EN
            };

        public string ToString(bool friendlyFormat, int indentation = 0)
        => LocalizedString;
        
    }
}