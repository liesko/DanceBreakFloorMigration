using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_scholarships:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_scholarships;");
            pMysql.Message = "tbl_scholarships - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                try
                {
                    pPostgres.Insert(
                        "insert into tbl_scholarships(scholarships_id, active, report_order, isclass, name, events_id) " +
                        "values('" + dataReader["id"]+ "','" + CheckBool(dataReader["active"].ToString()) + "','" + dataReader["report_order"] + "'," +
                        "'" +CheckBool(dataReader["isclass"].ToString()) + "','" + dataReader["name"] + "','" + dataReader["eventid"] + "');");
                }
                catch (Exception)
                {

                    pPostgres.Message = "INVALID INSERT:insert into tbl_scholarships(scholarships_id, active, report_order, isclass, name, events_id) " +
                        "values('" + dataReader["id"] + "','" + CheckBool(dataReader["active"].ToString()) + "','" + dataReader["report_order"] + "'," +
                        "'" + CheckBool(dataReader["isclass"].ToString()) + "','" + dataReader["name"] + "','" + dataReader["eventid"] + "');";
                }

            }
            pPostgres.Message = "tbl_scholarships - extraction - FINISH";
        }
        private int CheckBool(string pValue)
        {
            if (pValue == "True")
            {
                return 1;
            }
            return 0;
        }
    }
}