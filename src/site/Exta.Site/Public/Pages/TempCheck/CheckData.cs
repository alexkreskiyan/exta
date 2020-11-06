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
            Field(x => x.DocumentNumber).Required().MinLength(20).MaxLength(30);
            Field(x => x.OperationDate).Required();
            Field(x => x.CardNumber).Required().Length(4, 4).Must(x => int.TryParse(x, out _));
            Field(x => x.Sum).Required().Must(x => int.TryParse(x, out _));
            Field(x => x.Payer).Required().Length(15, 100);
        }
    }
}