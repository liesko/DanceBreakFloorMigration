﻿using System;
using System.Net;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_songs:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct song, artist from tbl_date_playlists;");
            pMysql.Message = "tbl_songs - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_songs(id, song_name, artist_name) " +
                                 "values(" + ++counter + ",'" + WebUtility.UrlDecode(dataReader[0].ToString()).Replace("'","''") + "','"+ WebUtility.UrlDecode(dataReader[1].ToString()).Replace("'", "''") + "')");
            }
            pPostgres.Message = "tbl_songs - extraction - FINISH";
        }
    }
}