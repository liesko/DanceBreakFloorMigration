using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_scholarships : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_scholarships");
            pMysql.Message = "Tbl_date_scholarships - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_scholarships(id, tour_dates_id, scholarships_id, winner, code) " +
                                 "values("+dataReader["id"]+","+dataReader["tourdateid"] +","+dataReader["scholarshipid"] +"," +
                                 ""+CheckBool(dataReader["winner"].ToString()) + ","+NVL(dataReader["code"].ToString()) + ")");
            }
            pPostgres.Message = "Tbl_date_scholarships - extraction - FINISH";
        }
    }
}