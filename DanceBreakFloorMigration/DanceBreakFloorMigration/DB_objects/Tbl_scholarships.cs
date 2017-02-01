using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_scholarships : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_scholarships;");
            pMysql.Message = "tbl_scholarships - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert(
                    "insert into tbl_scholarships(id, active, report_order, isclass, name, events_id) " +
                    "values('" + dataReader["id"] + "','" + CheckBool(dataReader["active"].ToString()) + "','" + dataReader["report_order"] + "'," +
                    "'" + CheckBool(dataReader["isclass"].ToString()) + "','" + dataReader["name"] + "','" + dataReader["eventid"] + "');");
            }
            pPostgres.Insert("insert into tbl_scholarships(id, events_id) values(14,6);");
            pPostgres.Message = "tbl_scholarships - extraction - FINISH";
        }
    }
}