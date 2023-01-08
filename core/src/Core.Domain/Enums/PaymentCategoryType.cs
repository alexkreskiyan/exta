using System.ComponentModel;

namespace Core.Domain.Enums;

public enum PaymentCategoryType
{
    [Description("Общий")]
    General,

    [Description("Авто")]
    Car
}
