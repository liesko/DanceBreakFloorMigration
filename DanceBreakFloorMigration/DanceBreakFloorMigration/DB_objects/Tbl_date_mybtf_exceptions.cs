using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_mybtf_exceptions : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_mybtf_exceptions;");
            pMysql.Message = "tbl_date_mybtf_exceptions - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_mybtf_exceptions(id, tour_dates_id, email, level) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["tourdateid"] + "','" + dataReader["email"] + "','" + dataReader["level"] + "')");
            }
            pPostgres.Message = "tbl_date_mybtf_exceptions - extraction - FINISH";
        }
    }
}