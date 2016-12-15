using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_schedule_competition:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_schedule_competition;");
            pMysql.Message = "tbl_date_schedule_competition - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                try
                {
                    pPostgres.Insert("insert into tbl_date_schedule_competition(schedule_competition_id, tour_dates_id,last_update,dates,awards) " +
                                 "values('" + dataReader["id"] + "'," +
                                 "'" + dataReader["tourdateid"] + "','" + dataReader["last_update"] + "','" + dataReader["dates"] + "','" + dataReader["awards"] + "')");
                }
                catch (Exception)
                {

                    pPostgres.Message = "INVALID INSERT: insert into tbl_date_schedule_competition(schedule_competition_id, tour_dates_id,last_update,dates,awards) " +
                                 "values('" + dataReader["id"] + "'," +
                                 "'" + dataReader["tourdateid"] + "','" + dataReader["last_update"].ToString().Replace("'","''") + "','" + dataReader["dates"].ToString().Replace("'", "''") + "','" + dataReader["awards"].ToString().Replace("'", "''") + "')";
                }
                
            }
            pPostgres.Message = "tbl_date_schedule_competition - extraction - FINISH";
        }
    }
}