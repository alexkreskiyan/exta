using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Exta.Site
{
    internal static class Locale
    {
        public static Dictionary<CultureInfo, IReadOnlyDictionary<string, string>> Data =
            new Dictionary<CultureInfo, IReadOnlyDictionary<string, string>>();

        static Locale()
        {
            Data.Add(new CultureInfo("ru-RU"), GetRussianLocale().ToDictionary(x => x.Item1, x => x.Item2));
        }

        private static IEnumerable<ValueTuple<string, string>> GetRussianLocale()
        {
            yield return ("TempCheck.Title", "Чек");
            yield return ("TempCheck.DocumentDate", "Дата документа");
            yield return ("TempCheck.DocumentNumber", "Номер документа");
            yield return ("TempCheck.OperationDate", "Дата операции");
            yield return ("TempCheck.CardNumber", "4 цифры номера карты");
            yield return ("TempCheck.Sum", "Сумма");
            yield return ("TempCheck.Payer", "Плательщик");
            yield return ("TempCheck.Create", "Создать");
        }
    }
}