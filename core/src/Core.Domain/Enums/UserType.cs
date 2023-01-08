using System.ComponentModel;

namespace Core.Domain.Enums;

public enum UserType
{
    [Description("Админ")]
    Admin,

    [Description("Водитель")]
    Driver
}
