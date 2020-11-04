using Annium.Blazor.Css;

namespace Exta.Site.Shared
{
    public class Style : IRuleSet
    {
        private readonly CssRule _html;

        public Style(Theme theme)
        {
            _html = Rule.Tag("html")
                .FontFamily(theme.FontFamily)
                .FontWeightNormal();
        }
    }
}