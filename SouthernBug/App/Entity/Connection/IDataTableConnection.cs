using System.Data;

namespace SouthernBug.App.Entity.Connection
{
    public interface IDataTableConnection
    {
        bool IsPushAvailable { get; }
        string[] IgnoredColumns { get; }
        DataTable LocalDataTable { get; }

        string TableName { get; }
        void Pull();
        void Push();

        object GetMeta(string key);
    }
}