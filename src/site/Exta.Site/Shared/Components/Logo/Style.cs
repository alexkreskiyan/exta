using Annium.Blazor.Css;

namespace Exta.Site.Shared.Components.Logo;

public class Style : IRuleSet
{
    public readonly CssRule Logo = Rule.Class()
        .WidthEm(1)
        .HeightEm(1);
}