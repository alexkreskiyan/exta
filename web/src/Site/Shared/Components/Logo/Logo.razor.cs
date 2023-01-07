using Annium.Blazor.Core.Tools;
using Microsoft.AspNetCore.Components;

namespace Site.Shared.Components.Logo;

public partial class Logo
{
    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    public string ClassName => ClassBuilder.With(Style.Logo).With(Class).Build();

}