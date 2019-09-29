using SouthernBug.App.Util;

namespace SouthernBug.App.Repository.TableContract.Contracts
{
    public class OperTableContract : BaseTableContract
    {
        public const string MetaRequiresYear = "OperTableContract.MetaRequiresYear";

        private const string ArgYear = "OperTableContract.ArgYear";

        public OperTableContract()
        {
            metaArgs.Add(MetaRequiresYear, true);
        }

        public static Args CreateArgs(string year)
        {
            return Args.Single(ArgYear, year);
        }

        public override string CreateSql()
        {
            return $"SELECT rowid, * FROM `{TableName}`" +
                   $" WHERE `{Tables.OperTables.Year}` = '{(string) args[ArgYear]}'";
        }

        protected override string[] GetHiddenColumns()
        {
            return new[] {Tables.OperTables.Year};
        }
    }
}