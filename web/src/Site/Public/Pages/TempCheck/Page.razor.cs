using System;
using Annium.Blazor.Core.Extensions;

namespace Site.Public.Pages.TempCheck;

public partial class Page : IDisposable
{
    private IDisposable _observerDisposer = default!;

    protected override void OnInitialized()
    {
        _observerDisposer = this.ObserveState(Store);
    }

    public void Dispose()
    {
        _observerDisposer.Dispose();
    }
}