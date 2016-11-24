using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Interfaces
{
    public interface IDB
    {
        bool OpenConnection();
        bool CloseConnection();
        void Insert(string pInsertString);
        void Update(string pUpdate);
        MySqlDataReader Select(string pQuery);

    }
}