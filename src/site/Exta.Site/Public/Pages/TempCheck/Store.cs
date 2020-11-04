using System.Threading.Tasks;
using Annium.Components.State.Forms;
using Annium.Components.State.Forms.Extensions;
using Annium.Components.State.Operations;
using Annium.Extensions.Validation;

namespace Exta.Site.Public.Pages.TempCheck
{
    internal class Store : IStore
    {
        public IObjectContainer<CheckData> Form { get; }
        public bool CanPrint => !Form.HasStatus(Status.Error, Status.Loading, Status.Validating) && Form.HasBeenTouched;
        public IOperationState State { get; } = OperationState.New();

        public Store(
            IStateFactory stateFactory,
            IValidator<CheckData> validator
        )
        {
            Form = stateFactory.Create(new CheckData());
            Form.UseValidator(validator);
        }

        public async Task Print()
        {
            State.Start();

            await Task.CompletedTask;

            State.Succeed();
        }
    }

    public interface IStore : Annium.Blazor.Storage.IStore
    {
        IObjectContainer<CheckData> Form { get; }
        bool CanPrint { get; }
        Task Print();
    }
}