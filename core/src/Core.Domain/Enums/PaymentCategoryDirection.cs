using System.ComponentModel;

namespace Core.Domain.Enums;

public enum PaymentCategoryDirection
{
    [Description("Доход")]
    Income,

    [Description("Расход")]
    Expense
}
