using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registration : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            // tbl_dts_registrations PART - FINISHER REG
            // ----------------------------------------------------------
            MySqlDataReader dataReader = pMysql.Select("select s.id, s.fname, s.lname, s.email, s.studio, s.phone, s.address, s.city, s.state, s.zip, s.country, " +
                                                       "s.date, s.fee, s.payment_method, s.title, s.organization, s.fax, s.cell, s.heard, s.details, s.tourdateid, " +
                                                       "s.confirmed, s.newdtsregid, s.deleted, s.neweventregid, s.viewed, s.independent, s.mybtfregid, s.enteredby, " +
                                                       "s.confirmdate, x.heard, x.notes, x.totalfees, x.feespaid, x.balancedue " +
                                                       "from registrations s left join tbl_dts_registrations x on (s.newdtsregid=x.id) where s.newdtsregid is not null and s.newdtsregid!=0;");
            pMysql.Message = "Tbl_registration - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_registration(id, tour_dates_id, studios_id) " +
                                 "values('"+dataReader["id"]+"','"+dataReader["tourdateid"] +"',"+ GetStudioId(dataReader["studio"].ToString(),pPostgres) +");");
            }
            // tbl_event_registrations PART- FINISHER REG
            // ----------------------------------------------------------
            MySqlDataReader dataReader2 = pMysql.Select("select s.id, s.fname, s.lname, s.email, s.studio, s.phone, s.address, s.city, s.state, s.zip, s.country, s.date, " +
                                                        "s.fee, s.payment_method, s.title, s.organization, s.fax, s.cell, s.heard, s.details, s.tourdateid, s.confirmed, " +
                                                        "s.newdtsregid, s.deleted, s.neweventregid, s.viewed, s.independent, s.mybtfregid, s.enteredby, s.confirmdate,x.profileid, " +
                                                        "x.notes, x.totalfees, x.feespaid, x.balancedue, x.studioid, x.id as oldid_event  " +
                                                        "from registrations s left join tbl_event_registrations x on(s.neweventregid=x.id) " +
                                                        "where s.neweventregid is not null and s.neweventregid !=0;");
            while (dataReader2.Read())
            {
                pPostgres.Insert("insert into tbl_registration(id, tour_dates_id, studios_id, oldid_event_reg) " +
                                 "values('" + dataReader2["id"] + "','" + dataReader2["tourdateid"] + "'," + NVL(dataReader2["studioid"].ToString()) + ", "+NVL(dataReader2["oldid_event"].ToString()) + ");");
            }


            // others PARTS from registration - FINISHER REG
            // ----------------------------------------------------------
            MySqlDataReader dataReader3 = pMysql.Select("select * from registrations s where (s.neweventregid is null or s.neweventregid=0) and (s.newdtsregid is null or s.newdtsregid=0);");
            while (dataReader3.Read())
            {
                pPostgres.Insert("insert into tbl_registration(id, tour_dates_id, studios_id) " +
                                 "values('" + dataReader3["id"] + "','" + dataReader3["tourdateid"] + "'," + GetStudioId(dataReader3["studio"].ToString(), pPostgres) + ");");
            }

            // UNFINISHED REG FROM tbl_event_registrations
            // ----------------------------------------------------------

            // UNFINISHED REG FROM tbl_dts_registrations
            // ----------------------------------------------------------
            MySqlDataReader dataReader5 = pMysql.Select("select * from tbl_dts_registrations");
            int MaxRegId = Convert.ToInt32(GetId("select max(id) from tbl_registration;", pPostgres));
            while (dataReader5.Read())
            {
                string pom= GetId("select id from tbl_registration where... ...")
                if ()
                {
                    pPostgres.Insert("insert into tbl_registration(id, tour_dates_id) " +
                                    "values('" + ++MaxRegId + "','" + dataReader5["tourdateid"] + "');");
                }
            }

            // END
            pPostgres.Message = "Tbl_registration - extraction - FINISH";
        }

        public string GetStudioId(string pStudio_name, PostgreSQL_DB pPostgres)
        {
            if (pStudio_name == null || pStudio_name == "")
            {
                return "null";
            }
            else
            {
                string studioId = GetId("select id from tbl_studios where name like '" + pStudio_name.Replace("'","''") + "'", pPostgres);
                if (studioId != null)
                {
                    return studioId;
                }
                else
                {
                    return AddNewStudio(pStudio_name, pPostgres);
                }
            }
        }
    }
}