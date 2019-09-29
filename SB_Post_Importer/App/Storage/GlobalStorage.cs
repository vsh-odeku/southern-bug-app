using System.Collections.Generic;

namespace SB_Post_Importer.App.Storage
{
    public static class GlobalStorage
    {
        private static readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public static object Get(string key)
        {
            return dictionary[key];
        }

        public static void Set(string key, object value)
        {
            dictionary[key] = value;
        }
    }
}