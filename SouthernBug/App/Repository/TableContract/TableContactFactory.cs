using System.Linq;
using SouthernBug.App.Repository.TableContract.Contracts;
using SouthernBug.App.Util;

namespace SouthernBug.App.Repository.TableContract
{
    public static class TableContractFactory
    {
        public static BaseTableContract Create(string tableName, Args args)
        {
            var contract = CreateContract(tableName);
            contract.Initialize(tableName, args);

            return contract;
        }

        private static BaseTableContract CreateContract(string tableName)
        {
            if (Tables.Names.OperTables.Contains(tableName)) return new OperTableContract();

            if (Tables.Names.PostTablesDic.ContainsKey(tableName)) return new PostsTableContract();

            return new CommonTableContract();
        }
    }
}