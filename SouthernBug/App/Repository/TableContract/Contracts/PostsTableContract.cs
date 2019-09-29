namespace SouthernBug.App.Repository.TableContract.Contracts
{
    public class PostsTableContract : BaseTableContract
    {
        public override string CreateSql()
        {
            var oi_hydro = Tables.Names.PostTablesDic[TableName];
            return $@"SELECT rowid, *
                                    FROM `Posts`
                                    WHERE `OI_Hydro` = '{oi_hydro}'";
        }

        protected override string[] GetHiddenColumns()
        {
            return new[] {"OI_Hydro"};
        }
    }
}