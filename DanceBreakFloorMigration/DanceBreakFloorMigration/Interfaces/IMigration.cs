using DanceBreakFloorMigration.Classes;

namespace DanceBreakFloorMigration.Interfaces
{
    public interface IMigration
    {
        void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500");
    }
}