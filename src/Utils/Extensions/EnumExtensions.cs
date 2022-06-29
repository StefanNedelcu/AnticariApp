using System.Reflection;

namespace AnticariApp.Utils.Extensions;

public static class EnumExtensions
{
    private static FieldInfo GetFieldInfo(Enum value)
    {
        return value.GetType().GetField(value.ToString());
    }

    public static long AsLong(this Enum value)
    {
        var fieldInfo = GetFieldInfo(value);
        return (long)fieldInfo.GetValue(value);
    }

    public static int AsInt(this Enum value)
    {
        var fieldInfo = GetFieldInfo(value);
        return (int)fieldInfo.GetValue(value);
    }

    public static T AsEnum<T>(this int value) where T : struct
    {
        if (!(typeof(T).IsEnum))
        {
            throw new ArgumentException("T must be an enumerated type");
        }

        return (T)Enum.Parse(typeof(T), value.ToString());
    }
}
