using System.Collections.Generic;

namespace SouthernBug.App.Util
{
    public class Args : Dictionary<string, object>
    {
        public static readonly Args Empty = new Args();

        public static Args Single(string key, object value)
        {
            return new Args
            {
                {key, value}
            };
        }

        public static Args EmptyIfNull(Args args)
        {
            if (args == null)
                return Empty;

            return args;
        }
    }
}