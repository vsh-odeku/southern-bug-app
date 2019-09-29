using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace SouthernBug.App.Util
{
    internal static class Etc
    {
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            // Ignore return value
            dictionary.TryGetValue(key, out var ret);
            return ret;
        }

        public static bool IsTrue(this object o)
        {
            return o != null && (bool) o;
        }

        public static void NoThrow(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                // ignored
            }
        }

        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}