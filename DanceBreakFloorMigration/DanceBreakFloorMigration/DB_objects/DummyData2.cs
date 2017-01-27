using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class DummyData2 : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            pMysql.Message = "DUMMY data2 GENERATE - START";
            

           
            pMysql.Message = "DUMMY data2 GENERATE - FINISH";
        }
    }
}