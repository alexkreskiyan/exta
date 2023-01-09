using System.ComponentModel;

namespace Core.Domain.Enums;

public enum AccrualReasonType
{
    [Description("Выезд")]
    Backup,

    [Description("Выходной")]
    DayOff,

    [Description("Скидка")]
    Discount,

    [Description("Долг")]
    Debt
}
