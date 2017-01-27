using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_user_has_dancer:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct userid, profileid from tbl_saved_dancers;");
            pMysql.Message = "tbl_user_has_dancer - extraction - START";
            while (dataReader.Read())
            {
                 pPostgres.Insert("insert into tbl_user_has_dancer(dancer_id, user_id) values('" + dataReader["profileid"] + "','" + dataReader["userid"] + "')");
            }
            pPostgres.Message = "tbl_user_has_dancer - extraction - FINISH";
        }
    }
}