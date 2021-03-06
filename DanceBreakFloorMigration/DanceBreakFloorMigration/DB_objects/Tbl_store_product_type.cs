﻿using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_product_type: IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name from store_product_types;");
            pMysql.Message = "tbl_store_product_types (from store_product_types)- extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_product_types(id, name) values('" + dataReader[0] + "','" + dataReader[1] + "')");
            }
            pPostgres.Message = "tbl_store_product_types - extraction - FINISH";
        }
    }
}