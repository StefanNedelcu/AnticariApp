using System.Reflection;

namespace ACUtils.Extensions
{
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
    }
}
