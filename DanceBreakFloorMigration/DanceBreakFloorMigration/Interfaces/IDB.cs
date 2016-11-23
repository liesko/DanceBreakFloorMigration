using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Interfaces
{
    public interface IDB
    {
        bool OpenConnection();
        bool CloseConnection();
        void Insert(string pInsertString);
        void Update();
        MySqlDataReader Select(string pQuery);

    }
}