using Annium.Blazor.Css;

namespace Site.Shared.Components.Logo;

public class Style : RuleSet
{
    public readonly CssRule Logo = Rule.Class()
        .WidthEm(1)
        .HeightEm(1);
}
