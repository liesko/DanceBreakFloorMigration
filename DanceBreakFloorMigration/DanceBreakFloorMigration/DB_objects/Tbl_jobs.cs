using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_jobs : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_jobs;");
            pMysql.Message = "tbl_jobs - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_jobs(id, title, jobtype, description, views, showonsite) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["title"] + "','" + dataReader["jobtype"] + "','" + dataReader["description"].ToString().Replace("'","''") + "','" + dataReader["views"] + "','" + CheckBool(dataReader["showonsite"].ToString()) + "')");
            }
            pPostgres.Message = "tbl_jobs - extraction - FINISH";
        }
    }
}