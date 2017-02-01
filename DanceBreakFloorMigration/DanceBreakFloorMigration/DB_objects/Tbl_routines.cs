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
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            try
            {
                DummyStudioCreation(pMysql, pPostgres);
            }
            catch (Exception)
            {
            }
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(2924, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(8023, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(8024, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(11604, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(37012, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(78757,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(78681,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(80857,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(88247,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(79272,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(89721,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(89381,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(99410,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(92734,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(99786,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(100022,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(106053,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(100302,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(107876,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109241,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(112241,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(111469,0,'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(111236,0,'DUMMY');");

            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1189, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1177, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1176, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1183, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1174, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1178, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1179, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1175, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1186, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(1187, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(76177, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109212, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(0, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(52187, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(76193, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(76427, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(77296, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(76191, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(108262, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(108491, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109210, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(108489, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109216, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109211, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109611, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(109610, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(110660, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(110649, 0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values(110661, 0, 'DUMMY');");

            MySqlDataReader dataReader = pMysql.Select("select * from tbl_routines;");
            pMysql.Message = "tbl_routines - extraction - START - studio OWNERS";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_routines(id, studios_id, name) " +
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
                    string name = "";
                    if (word.Contains(" "))
                    {
                        name = word.Substring(0, Strings.InStr(1, word, " ") - 1);
                    }                    
                    string surname = word.Substring(Strings.InStr(1, word, " "));
                    string personid = GetId("select id from tbl_person where fname like '" + name.Replace("'", "''") + "' and lname like '" + surname.Replace("'", "''") + "' LIMIT 1;", pPostgres);
                    if (personid=="null")
                    {
                        pPostgres.Insert("insert into tbl_person(fname, lname) values('" + name.Replace("'", "''") + "','" + surname.Replace("'", "''") + "')");
                        personid = GetId("select max(id) from tbl_person;", pPostgres);
                    }
                    if (!RowExists(personid, proutine_id, pPostgres))
                    {
                        pPostgres.Insert("insert into tbl_routines_has_teacher(person_id, routine_id) values('" + personid + "','" + proutine_id + "')");
                    }             
            }
        }
        private void DummyStudioCreation(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct studioid from tbl_routines where studioid not in (select id from tbl_studios);");
            pMysql.Message = "DUMMY tbl_studios - extraction - START";
            while (dataReader.Read())
            {
                string Exists = GetId("select id from tbl_studios where id='"+ dataReader[0] + "'", pPostgres);
                if (Exists=="null")
                {
                    pPostgres.Insert("insert into tbl_studios(id, name) values('" + dataReader[0] + "','DUMMY DANCE STUDIO')");
                }
            }
            pPostgres.Message = "DUMMY tbl_studios - extraction - FINISH";
        }

        private bool RowExists(string p_person_id, string p_routine_id, PostgreSQL_DB pPostgres)
        {
            string pom=GetId("select person_id from tbl_routines_has_teacher where person_id = '"+p_person_id+"' and routine_id = '"+p_routine_id+"'", pPostgres);
            if (pom=="null")
            {
                return false;
            }
            return true;
        }
    }
}