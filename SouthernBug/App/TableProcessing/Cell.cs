using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SouthernBug.App.TableProcessing
{
    public class Cell
    {
        public Cell(object rawValue)
        {
            RawValue = rawValue;
        }

        public object RawValue { get; }

        public string StringValue => RawValue.ToString().Trim();

        public bool IsEmpty => StringValue == "";

        public int IntValue => int.Parse(StringValue);

        public double DoubleValue
        {
            get
            {
                if (RawValue is double d)
                    return d;
                return double.Parse(StringValue.Replace(',', '.'),
                    CultureInfo.InvariantCulture);
            }
        }

        public List<int> ToIntList()
        {
            var strArr = StringValue.Replace(" ", "").Split(',');
            var number = 0;
            var intArr = from str in strArr
                where int.TryParse(str, out number)
                select number;

            return intArr.ToList();
        }
    }
}