namespace SouthernBug.App.Calculation.Unit._0_Always
{
    internal class Calc_Page00_UserInput : BaseCalc
    {
        public override void Perform()
        {
            tables.UserInputTable.SetUserInput(userInput);
        }
    }
}