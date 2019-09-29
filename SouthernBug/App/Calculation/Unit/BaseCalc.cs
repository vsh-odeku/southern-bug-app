using System;
using System.Collections.Generic;
using SouthernBug.App.Model;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit
{
    public abstract class BaseCalc
    {
        protected CalcBranch calcBranch;
        protected Dictionary<string, object> calcMemory;
        protected int calcYear;
        protected DateParser dateParser;
        protected MainCalcTables tables;
        protected Dictionary<string, string> userInput;

        public void Initialize(MainCalcTables tables,
            Dictionary<string, string> userInput,
            Dictionary<string, object> calcMemory)
        {
            this.tables = tables;
            this.userInput = userInput;
            this.calcMemory = calcMemory;

            calcBranch = new CalcBranch(userInput);

            calcYear = int.Parse(userInput[CalculationsForm.Arg_Year]);
            dateParser = new DateParser(calcYear);
        }

        public abstract void Perform();

        protected void DebugInterrupt(string reason)
        {
            throw new CalcDebugInterruptException(reason);
        }

        protected void DebugInterrupt()
        {
            DebugInterrupt("No reason");
        }

        protected DateTime GetDate(Cell cell)
        {
            return dateParser.ParseDayMonth(cell.StringValue);
        }
    }
}