using System.Collections.Generic;

namespace SouthernBug.App.Calculation.Table
{
    public class UserInputTable : TableProcessing.Table
    {
        public UserInputTable(string name) : base(name)
        {
        }

        public void SetUserInput(Dictionary<string, string> userInput)
        {
            AddColumns("Key", "Value");

            foreach (var entry in userInput) AddRow(entry.Key, entry.Value);
        }
    }
}