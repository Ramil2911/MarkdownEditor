using Svg.ExCSS;

namespace text_editor.Internationalization
{
    public interface ILocalizable : IToString
    {
        public string LOCAL_RU {get; init; }
        public string LOCAL_EN { get; init; }
        public string LocalizedString { get; }
    }
}