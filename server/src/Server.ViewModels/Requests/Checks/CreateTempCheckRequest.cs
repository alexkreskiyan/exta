using System;
using Annium.Architecture.ViewModel;
using Server.Domain.Queries.Checks;

namespace Server.ViewModels.Requests.Checks;

public class CreateTempCheckRequest : IRequest<CreateTempCheckQuery>
{
    public DateTime DocumentDate { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DateTime OperationDate { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string Sum { get; set; } = string.Empty;
    public string Payer { get; set; } = string.Empty;
}
