namespace SouthernBug.App.Repository.TableContract.Contracts
{
    public class CommonTableContract : BaseTableContract
    {
        public override string CreateSql()
        {
            return $"SELECT rowid, * FROM `{TableName}`";
        }
    }
}