using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_dancers : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select *, cast(workshoplevelid as char) as workshoplevelid2 from tbl_date_dancers;");
            pMysql.Message = "Tbl_date_dancers - extraction - START ";
            while (dataReader.Read())
            {
                string pFee = dataReader["fee"].ToString();
                if (String.IsNullOrEmpty(pFee) || pFee== "yrtrdsdsnvhrxz3syy.n")
                {
                    pFee = "0";
                }
                // -------------------
                if (!String.IsNullOrEmpty(dataReader["profileid"].ToString()))
                {
                    CreateDummyDancer(NVL(dataReader["profileid"].ToString()), pPostgres);
                }
                // -------------------
                if (!String.IsNullOrEmpty(dataReader["workshoplevelid2"].ToString()))
                {
                    CreateDummyWorkshopLevel(NVL(dataReader["workshoplevelid2"].ToString()), pPostgres);
                }
                // -------------------

                if (!String.IsNullOrEmpty(dataReader["statsregid"].ToString()))
                {
                    CreateDummyRegistration(NVL(dataReader["statsregid"].ToString()), pPostgres);
                }
                // -------------------
                if (!String.IsNullOrEmpty(dataReader["studioid"].ToString()))
                {
                    CreateDummyStudio(NVL(dataReader["studioid"].ToString()), pPostgres);
                }
                // -------------------
                if (!String.IsNullOrEmpty(dataReader["waiverid"].ToString()))
                {
                    CreateDummyWaiver(NVL(dataReader["waiverid"].ToString()), pPostgres);
                }
                

                pPostgres.Insert("insert into tbl_date_dancers(id, fee, age, one_day, has_scholarship, custom_fee, waiver, attended_reg, " +
                                 "has_photo, vip, independent, vip_type, scholarship_code, attended_reg_both, dancer_id, studios_id, tour_dates_id, " +
                                 "statsregid, waivers_id, workshop_levels_id) " +
                                 "values("+dataReader["id"]+ ",'" + pFee + "'," + dataReader["age"] + "," + CheckBool(dataReader["one_day"].ToString()) + "," + CheckBool(dataReader["has_scholarship"].ToString()) + "," +
                                 "" + CheckBool(dataReader["custom_fee"].ToString()) + "," + CheckBool(dataReader["waiver"].ToString()) + "," + CheckBool(dataReader["attended_reg"].ToString()) + "," + CheckBool(dataReader["has_photo"].ToString()) + "," + CheckBool(dataReader["vip"].ToString()) + "," +
                                 "" + CheckBool(dataReader["independent"].ToString()) + ",'" + dataReader["vip_type"].ToString().Replace("'","''") + "'," + NVL(dataReader["scholarship_code"].ToString()) + "," + CheckBool(dataReader["attended_reg_both"].ToString()) + "," + NVL(dataReader["profileid"].ToString()) + "," +
                                 "" + NVL(dataReader["studioid"].ToString()) + "," + NVL(dataReader["tourdateid"].ToString()) + ","+NVL(dataReader["statsregid"].ToString()) + ", "+NVL(dataReader["waiverid"].ToString()) + ","+NVL(dataReader["workshoplevelid2"].ToString()) + ");");
            }
            pPostgres.Message = "Tbl_date_dancers - extraction - FINISH";
        }

        public string DancerExists(string dancer_id, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_waivers where id = " + dancer_id+";", pPostgres);
            return check;
        }

        public void CreateDummyWaiver(string pWaiverId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_waivers where id = " + pWaiverId + ";", pPostgres);
            if (check=="null")
            {
                pPostgres.Insert("insert into tbl_waivers(id, dancer_id) values("+ pWaiverId + ", 20797);");
            }
        }
        public void CreateDummyStudio(string pStudio, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_studios where id = " + pStudio + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_studios(id, name) values("+ pStudio + ",'DUMMY DANCE STUDIO');");
            }
        }
        public void CreateDummyRegistration(string pRegistration, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_registration where id = " + pRegistration + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_registration(id) values(" +pRegistration+");");
            }
        }
        public void CreateDummyWorkshopLevel(string pWorkshopLevel, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_workshop_levels where id = " + pWorkshopLevel + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_workshop_levels(id, playlist_workshop_levels_id, season_id) values("+ pWorkshopLevel + ",0,0);");
            }
        }
        public void CreateDummyDancer(string pDancerId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_dancer where id = " + pDancerId + ";", pPostgres);
            if (check == "null" )
            {
                pPostgres.Insert("insert into tbl_dancer(id, person_id) values("+ pDancerId + ",0);");
            }
        }
    }
}