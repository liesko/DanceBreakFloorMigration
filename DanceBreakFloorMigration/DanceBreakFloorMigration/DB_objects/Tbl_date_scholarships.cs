using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_scholarships : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_scholarships");
            pMysql.Message = "Tbl_date_scholarships - extraction - START ";
            while (dataReader.Read())
            {
                // -------------------
                if (!String.IsNullOrEmpty(dataReader["facultyid"].ToString()))
                {
                    CreateDummyFaculty(NVL(dataReader["facultyid"].ToString()), pPostgres);
                }

                // -------------------
                if (!String.IsNullOrEmpty(dataReader["datedancerid"].ToString()))
                {
                    CreateDummyTblDateDancers(NVL(dataReader["datedancerid"].ToString()), pPostgres);
                }

                pPostgres.Insert("insert into tbl_date_scholarships(id, tour_dates_id, scholarships_id, winner, code, faculty_id, dancer_id, date_dancer_id) " +
                                 "values("+dataReader["id"]+","+dataReader["tourdateid"] +","+dataReader["scholarshipid"] +"," +
                                 ""+CheckBool(dataReader["winner"].ToString()) + ","+NVL(dataReader["code"].ToString()) + ","+NVL(dataReader["facultyid"].ToString()) + "," +
                                 ""+NVL(dataReader["profileid"].ToString()) + ","+NVL(dataReader["datedancerid"].ToString()) + ")");
            }
            pPostgres.Message = "Tbl_date_scholarships - extraction - FINISH";
        }
    }
}