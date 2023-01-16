using Annium.Extensions.Validation;
using Server.Domain.Queries.Checks;

namespace Server.Application.Queries.Checks;

internal class CreateTempCheckQueryValidator : Validator<CreateTempCheckQuery>
{
    public CreateTempCheckQueryValidator(
    )
    {
        Field(x => x.DocumentDate).Required();
        Field(x => x.DocumentNumber).Required().MinLength(20).MaxLength(30);
        Field(x => x.OperationDate).Required();
        Field(x => x.CardNumber).Required().Between(1000, 9999);
        Field(x => x.Sum).Required();
        Field(x => x.Payer).Required().Length(15, 100);
    }
}
