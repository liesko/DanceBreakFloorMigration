using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_hearts : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_hearts;");
            pMysql.Message = "tbl_store_hearts - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_hearts(id, routine_id, individual_id, is_video, hearts, url) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["routineid"] + "','" + CheckBool(dataReader["is_video"].ToString()) + "'," +
                                 "'" + dataReader["individual_id"] + "','" + dataReader["hearts"] + "','" + dataReader["url"] + "')");
            }
            pPostgres.Message = "tbl_store_hearts - extraction - FINISH";
        }
    }
}