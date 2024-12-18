namespace FluentV.Core.Validations
{
    public static partial class Validations
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }
    }
}
