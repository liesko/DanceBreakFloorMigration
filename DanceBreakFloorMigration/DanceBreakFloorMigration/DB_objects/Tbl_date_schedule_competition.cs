using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_schedule_competition : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_schedule_competition;");
            pMysql.Message = "tbl_date_schedule_competition - extraction - START";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_date_schedule_competition(id, tour_dates_id,last_update,dates,awards) " +
                                 "values('" + dataReader["id"] + "'," +
                                 "'" + dataReader["tourdateid"] + "'," + NVL(dataReader["last_update"].ToString().Replace("'","''")) + "," + NVL(dataReader["dates"].ToString().Replace("'", "''")) + "," + NVL(dataReader["awards"].ToString().Replace("'", "''")) + ")");
            }
            pPostgres.Message = "tbl_date_schedule_competition - extraction - FINISH";
        }
    }
}