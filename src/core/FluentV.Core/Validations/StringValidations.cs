namespace FluentV.Core.Validations
{
    public static partial class Validations
    {
        public static bool IsEmptyString(this string value)
        {
            return value == string.Empty;
        }

        public static bool IsWhiteSpaceString(this string value)
        {
            foreach ( char c in value )
            {
                if ( !char.IsWhiteSpace(c) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
