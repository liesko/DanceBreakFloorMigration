using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_online_critiques_access:IMigration 
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_online_critiques_access;");
            pMysql.Message = "tbl_online_critiques_access - extraction - START";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_online_critiques_access(id, tour_dates_id, studios_id, accesscode) " +
                                 "values('" + dataReader["id"] + "'," +
                                 "'" + dataReader["tourdateid"] + "','" + dataReader["studioid"] + "','" + dataReader["accesscode"] + "')");
            }
            pPostgres.Message = "tbl_online_critiques_access - extraction - FINISH";
        }
    }
}