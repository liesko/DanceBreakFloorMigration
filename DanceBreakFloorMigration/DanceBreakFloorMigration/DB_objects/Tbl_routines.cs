using System;
using System.Collections.Generic;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Npgsql;
using NpgsqlTypes;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_routines : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            try
            {
                DummyStudioCreation(pMysql, pPostgres);
            }
            catch (Exception)
            {
            }
            
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_routines;");
            pMysql.Message = "tbl_routines - extraction - START - studio OWNERS";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_routines(routine_id, studios_id, name) " +
                                 "values('" + dataReader["id"] + "','" + dataReader["studioid"] + "','" + dataReader["name"].ToString().Replace("'", "''") + "');");
                    if (dataReader["teacher"].ToString().Length > 0)
                    {
                        ManageTeacher(dataReader["teacher"].ToString(), dataReader["id"].ToString(), pPostgres);
                    }
            }
            pPostgres.Message = "tbl_routines - extraction - FINISH - studio OWNERS";
        }

        private void ManageTeacher(string pTeacher, string proutine_id, PostgreSQL_DB pPostgres)
        {
            string s = pTeacher;
            string[] words = s.Split('/');
            foreach (string word in words)
            {
                try
                {
                    string name = word.Substring(0, Strings.InStr(1, word, " ") - 1);
                    string surname = word.Substring(Strings.InStr(1, word, " "));
                    string personid = GetId("select person_id from tbl_person where fname like '" + name.Replace("'", "''") + "' and lname like '" + surname.Replace("'", "''") + "' LIMIT 1;", pPostgres);
                    if (personid == null)
                    {
                        pPostgres.Insert("insert into tbl_person(fname, lname) values('" + name.Replace("'", "''") + "','" + surname.Replace("'", "''") + "')");
                        personid = GetId("select max(person_id) from tbl_person;", pPostgres);
                    }
                    pPostgres.Insert("insert into tbl_routines_has_teacher(person_id, routine_id) values('" + personid + "','" + proutine_id + "')");
                }
                catch (Exception)
                {
                }
            }
        }
        private void DummyStudioCreation(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct studioid from tbl_routines where studioid not in (select id from tbl_studios);");
            pMysql.Message = "DUMMY tbl_studios - extraction - START";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_studios(studios_id, name) values('" + dataReader[0] + "','DUMMY DANCE STUDIO')");
            }
            pPostgres.Message = "DUMMY tbl_studios - extraction - FINISH";
        }
    }
}