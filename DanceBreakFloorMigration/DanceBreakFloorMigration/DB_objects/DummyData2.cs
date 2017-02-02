using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class DummyData2 : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pMysql.Message = "DUMMY data2 GENERATE - START";
            

           
            pMysql.Message = "DUMMY data2 GENERATE - FINISH";
        }
    }
}