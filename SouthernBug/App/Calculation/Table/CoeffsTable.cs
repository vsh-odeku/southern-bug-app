﻿namespace SouthernBug.App.Calculation.Table
{
    internal class CoeffsTable : TableProcessing.Table
    {
        public CoeffsTable(string name) : base(name)
        {
            AddColumns("Рівняння", "a", "b");
        }
    }
}