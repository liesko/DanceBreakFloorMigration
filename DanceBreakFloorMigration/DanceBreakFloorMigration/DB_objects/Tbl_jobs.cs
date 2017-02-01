using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_jobs : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate="1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_jobs;");
            pMysql.Message = "tbl_jobs - extraction - START";
            while (dataReader.Read())
            {
                if (!String.IsNullOrEmpty(dataReader["insert_date"].ToString()) && Convert.ToDateTime(dataReader["insert_date"].ToString())> Convert.ToDateTime(pDate))
                {                                    
                pPostgres.Insert("insert into tbl_jobs(id, title, jobtype, description, views, showonsite) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["title"] + "','" + dataReader["jobtype"] + "','" + dataReader["description"].ToString().Replace("'","''") + "','" + dataReader["views"] + "','" + CheckBool(dataReader["showonsite"].ToString()) + "')");
                }
            }
            pPostgres.Message = "tbl_jobs - extraction - FINISH";
        }
    }
}