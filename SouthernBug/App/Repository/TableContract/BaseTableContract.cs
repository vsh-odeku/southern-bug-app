using System.Linq;
using SouthernBug.App.Util;

namespace SouthernBug.App.Repository.TableContract
{
    public abstract class BaseTableContract
    {
        private readonly string[] _baseHiddenColumns = {"rowid"};

        protected Args args;
        protected Args metaArgs = new Args();

        public string TableName { get; private set; }
        public string[] HiddenColumns { get; private set; }

        public void Initialize(string tableName, Args args)
        {
            TableName = tableName;
            this.args = Args.EmptyIfNull(args);

            InitHiddenColumns();
        }

        public abstract string CreateSql();

        public object GetMeta(string key)
        {
            return metaArgs.GetValueOrDefault(key);
        }

        protected virtual string[] GetHiddenColumns()
        {
            return new string[] { };
        }

        private void InitHiddenColumns()
        {
            HiddenColumns = _baseHiddenColumns
                .Concat(GetHiddenColumns())
                .ToArray();
        }
    }
}