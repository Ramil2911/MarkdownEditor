namespace text_editor.Controls
{
    public class Code : Text
    {
        public override string Name { get; } = "Code";

        public override string ToMarkdown()
        {
            return "```\n"+TextStr+"\n```";
        }
    }
}