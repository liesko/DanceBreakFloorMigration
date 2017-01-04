using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_giftcards : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_giftcards;");
            pMysql.Message = "tbl_store_giftcards - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_giftcards(id, code, initial_balance, balance, created) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["code"] + "','" + dataReader["initial_balance"] + "','" + dataReader["balance"] + "','" + FromUnixTime(Convert.ToInt64(dataReader["created"])).ToString().Replace(". ", ".") + "')");
            }
            pPostgres.Message = "tbl_store_giftcards - extraction - FINISH";
        }
    }
}