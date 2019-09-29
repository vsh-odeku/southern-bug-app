using System.Collections.Generic;
using SouthernBug.App.Calculation.Unit;
using SouthernBug.App.Calculation.Unit._0_Always;
using SouthernBug.App.Calculation.Unit._1_Y_Only;
using SouthernBug.App.Calculation.Unit._2_Qm_Only;
using SouthernBug.App.Calculation.Unit._3_D_Only;
using SouthernBug.App.Calculation.Unit._4_PostProcessing;

namespace SouthernBug.App.Calculation
{
    internal static class MainCalcUnits
    {
        public static List<BaseCalc> LoadAllCalcs()
        {
            return new List<BaseCalc>
            {
                new Calc_Page00_UserInput(),
                new Calc_Page01_BlockA(),
                new Calc_Page02_Block1Be(),
                new Calc_Page02_Block2Ve(),
                new Calc_Page03_BlockGe(),
                new Calc_Page04_05_BlockDe1_1(),
                new Calc_Page06_BlockDe3(),
                new Calc_Page08_09_BlockE1(),
                new Calc_Page10(),
                new Calc_Page11(),
                new Calc_Page12_13_BlockE2(),
                new Calc_Page14_BlockE2_6(),
                new Calc_Page14_BlockE2_7(),
                new Calc_Page15(),
                new Calc_Page16(),
                new Calc_Page17_0_Init(),
                new Calc_Page17_BlockZe1_1(),
                new Calc_Page17_BlockZe1_2_And_1_3_And_Page18_All(),
                new Calc_Page19(),
                new Calc_PostProcessing()
            };
        }
    }
}