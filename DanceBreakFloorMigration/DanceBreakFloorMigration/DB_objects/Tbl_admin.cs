﻿using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_admin : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from users;");
            pMysql.Message = "Tbl_admin - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into Tbl_admin(id, password, last_login, ip, name, theme, financials, accesslevel) " +
                                 "values('"+dataReader["id"]+"','"+dataReader["password"]+"','"+dataReader["last_login"]+"','"+dataReader["ip"]+"'," +
                                 "'"+dataReader["name"]+"','"+dataReader["theme"]+ "','" + CheckBool(dataReader["financials"].ToString()) + "','" +CheckBool(dataReader["accesslevel"].ToString()) + "');");
            }
            pPostgres.Message = "Tbl_admin - extraction - FINISH";
        }
    }
}