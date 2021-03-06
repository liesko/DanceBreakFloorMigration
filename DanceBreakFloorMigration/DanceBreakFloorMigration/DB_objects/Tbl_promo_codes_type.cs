﻿using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_promo_codes_type:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct type from promo_codes;");
            pMysql.Message = "tbl_promo_codes_type (from promo_codes)- extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_promo_codes_type(id,name) " +
                                 "values('" + ++counter + "','" + dataReader[0]+"')");
            }
            pPostgres.Message = "tbl_promo_codes_type - extraction - FINISH";
        }
    }
}