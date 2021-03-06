﻿using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_product_colors:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_product_colors;");
            pMysql.Message = "tbl_store_products - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_product_colors(store_colors_id, store_products_id) values('"+dataReader["colorid"] +"','"+dataReader["productid"] +"')");
            }
            pPostgres.Message = "store_product_colors - extraction - FINISH";
        }
    }
}