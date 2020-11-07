using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Annium.Architecture.Base;
using Annium.Architecture.CQRS.Queries;
using Annium.Core.Runtime.Resources;
using Annium.Data.Operations;
using Exta.Api.Application.Extensions;
using Exta.Api.Application.Queries.Checks;
using Exta.Domain.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Exta.Api.Application.QueryHandlers
{
    public class TempCheckQueryHandler : IQueryHandler<CreateTempCheckQuery, TempCheck>
    {
        private readonly IResourceLoader _resourceLoader;

        public TempCheckQueryHandler(
            IResourceLoader resourceLoader
        )
        {
            _resourceLoader = resourceLoader;
        }

        public Task<IStatusResult<OperationStatus, TempCheck>> HandleAsync(
            CreateTempCheckQuery request,
            CancellationToken ct
        )
        {
            var random = new Random();
            var docDate = request.DocumentDate.ToString("dd.MM.yyyy");
            var docNum = request.DocumentNumber;
            var operationDate = request.OperationDate.ToString("dd.MM.yyyy");
            var cardNum = request.CardNumber;
            var sum = request.Sum;
            var payeer = request.Payer;

            var resource = _resourceLoader.Load("Resources", GetType().Assembly).Single(x => x.Name == "source.png");

            using var image = Image.Load(resource.Content.Span);
            image.Mutate(ctx => ctx
                .Text(60, 524, $"ДАТА ОПЕРАЦИИ:  {operationDate}")
                .Text(60, 595, $"ВРЕМЯ ОПЕРАЦИИ (МСК):  {DateTime.Now.Date.AddHours(10).AddSeconds(random.Next(8 * 60 * 60)).ToString("HH:mm:ss")}")
                .Text(60, 665, $"НОМЕР ДОКУМЕНТА:  {random.Next(661000, 662000)}")
                .Text(60, 783, $"ОТПРАВИТЕЛЬ: № КАРТЫ: **** {cardNum.ToString()}")
                .Text(60, 853, $"СУММА ОПЕРАЦИИ:  {sum:0.00} РУБ.")
                .Text(60, 924, $"КОМИССИЯ:  {sum / 100:0.00}")
                .Text(60, 995, $"КОД АВТОРИЗАЦИИ:  {random.Next(728000, 729000)}")
                .Text(60, 1065, $"РЕКВИЗИТЫ ПЛАТЕЛЬЩИКА:   {payeer}")
                .Text(60, 1135, $"НОМЕР ДОКУМЕНТА:  {docNum}")
                .Text(60, 1205, $"ДАТА ДОКУМЕНТА:  {docDate}")
                .Text(60, 1275, "КПП:  673001001")
                .Text(60, 1347, "БАНК ПОЛУЧАТЕЛЯ:  ОТДЕЛЕНИЕ СМОЛЕНСК")
                .Text(60, 1417, "КБК:  1881163002001600140")
                .Text(60, 1487, "ОКТМО:  66701000")
                .Text(60, 1558, $"СУММА ШТРАФА:  {sum:0.00}")
                .Text(60, 1628, $"СУММА К ОПЛАТЕ:  {sum:0.00}")
                .Text(60, 1698, "НАЗНАЧЕНИЕ ПЛАТЕЖА:")
                .Text(60, 1734, "ШТРАФ ПО АДМИНИСТРАТИВНОМУ ПРАВОНАРУШЕНИЮ")
                .Text(60, 1769, $"ПОСТАНОВЛЕНИЕ № {docNum}")
                .Text(60, 1836, $"УИН:  {docNum}")
                .Text(60, 1907, "УИП:  10466146320086090207201744157254")
                .Text(60, 1977, $"СУММА ПЛАТЕЖА:  {sum:0.00}")
                .Text(60, 2047, "УНИКАЛЬНЫЙ НОМЕР ПЛАТЕЖА(СУИП):  400020562289NGNW")
                .Text(60, 2119, "ПОЛУЧАТЕЛЬ ПЛАТЕЖА:")
                .Text(60, 2155, "УФК ПО СМОЛЕНСКОЙ ОБЛАСТИ (УМВД РОССИИ ПО")
                .Text(60, 2190, "СМОЛЕНСКОЙ ОБЛАСТИ Л/С 04631205420")
                .Text(60, 2257, "БИК:  046614001")
                .Text(60, 2327, "ИНН:  6730013564")
                .Text(60, 2398, "СЧЕТ:  40101810200000010001")
                .Text(60, 2471, "НАИМЕНОВАНИЕ БАНКА ПОЛУЧАТЕЛЯ:")
                .Text(60, 2507, "ОТДЕЛЕНИЕ СМОЛЕНСК")
            );

            using var ms = new MemoryStream();
            image.SaveAsPng(ms);

            var check = new TempCheck("image/png", ms.ToArray());

            return Task.FromResult(Result.Status(OperationStatus.OK, check));
        }
    }
}