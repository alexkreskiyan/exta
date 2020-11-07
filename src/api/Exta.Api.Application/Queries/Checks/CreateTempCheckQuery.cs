using System;
using Annium.Architecture.CQRS.Queries;

namespace Exta.Api.Application.Queries.Checks
{
    public class CreateTempCheckQuery : IQuery
    {
        public DateTime DocumentDate { get; }
        public string DocumentNumber { get; }
        public DateTime OperationDate { get; }
        public int CardNumber { get; }
        public int Sum { get; }
        public string Payer { get; }

        public CreateTempCheckQuery(
            DateTime documentDate,
            string documentNumber,
            DateTime operationDate,
            int cardNumber,
            int sum,
            string payer
        )
        {
            DocumentDate = documentDate;
            DocumentNumber = documentNumber;
            OperationDate = operationDate;
            CardNumber = cardNumber;
            Sum = sum;
            Payer = payer;
        }
    }
}