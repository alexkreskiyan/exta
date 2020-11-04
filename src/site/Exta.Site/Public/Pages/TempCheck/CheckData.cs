using System;
using Annium.Extensions.Validation;

namespace Exta.Site.Public.Pages.TempCheck
{
    public class CheckData
    {
        public DateTime DocumentDate { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime OperationDate { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string Sum { get; set; } = string.Empty;
        public string Payer { get; set; } = string.Empty;
    }

    public class LoginDataValidator : Validator<CheckData>
    {
        public LoginDataValidator()
        {
            Field(x => x.DocumentDate).Required();
            Field(x => x.DocumentNumber).Required().Then().MinLength(20).MaxLength(30);
            Field(x => x.OperationDate).Required();
            Field(x => x.CardNumber).Required().Then().Length(4, 4);
            Field(x => x.Sum).Required().Then().Length(3, 5);
            Field(x => x.Payer).Required().Then().Length(15, 100);
        }
    }
}