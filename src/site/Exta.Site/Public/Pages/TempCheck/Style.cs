using Annium.Blazor.Css;

namespace Exta.Site.Public.Pages.TempCheck
{
    public class Style : IRuleSet
    {
        public CssRule Title { get; } = Rule.Class()
            .MarginTopRem(1);

        public CssRule Form { get; } = Rule.Class()
            .WidthPercent(100)
            .MarginTopRem(1);

        public CssRule FormItem { get; } = Rule.Class()
            .FontSizeRem(1)
            .MarginBottomRem(0)
            .Inheritor("input", input => input.FontSizeRem(1));
    }
}