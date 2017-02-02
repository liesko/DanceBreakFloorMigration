using DanceBreakFloorMigration.Classes;

namespace DanceBreakFloorMigration.Interfaces
{
    public interface IMigration
    {
        void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500");
    }
}