using System.Threading.Tasks;
using Annium.Components.State.Forms;
using Annium.Components.State.Forms.Extensions;
using Annium.Components.State.Operations;
using Annium.Extensions.Validation;
using Annium.Net.Base;
using Exta.Site.Shared;
using Microsoft.JSInterop;

namespace Exta.Site.Public.Pages.TempCheck
{
    internal class Store : IStore
    {
        public IObjectContainer<CheckData> Form { get; }
        public bool CanCreate => !Form.HasStatus(Status.Error, Status.Loading, Status.Validating) && Form.HasBeenTouched;
        public IOperationState State { get; } = OperationState.New();
        private readonly Configuration _cfg;
        private readonly IJSRuntime _js;

        public Store(
            IStateFactory stateFactory,
            IValidator<CheckData> validator,
            Configuration cfg,
            IJSRuntime js
        )
        {
            _cfg = cfg;
            _js = js;
            Form = stateFactory.Create(new CheckData());
            Form.UseValidator(validator);
        }

        public async Task Create()
        {
            State.Start();

            var data = Form.Value;
            var url = UriFactory.Base(_cfg.Server)
                .Path("/temp-check")
                .Param(nameof(CheckData.DocumentDate), data.DocumentDate.ToString("s"))
                .Param(nameof(CheckData.DocumentNumber), data.DocumentNumber)
                .Param(nameof(CheckData.OperationDate), data.OperationDate.ToString("s"))
                .Param(nameof(CheckData.CardNumber), data.CardNumber)
                .Param(nameof(CheckData.Sum), data.Sum)
                .Param(nameof(CheckData.Payer), data.Payer)
                .Build();

            await _js.InvokeAsync<object>("open", url, "_blank");

            State.Succeed();
        }
    }

    public interface IStore : Annium.Blazor.Storage.IStore
    {
        IObjectContainer<CheckData> Form { get; }
        bool CanCreate { get; }
        Task Create();
    }
}