using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registration : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            // tbl_dts_registrations PART
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
            // tbl_event_registrations PART
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
                                 "values('" + dataReader["id"] + "','" + dataReader["tourdateid"] + "'," + GetStudioId(dataReader["studio"].ToString(), pPostgres) + ");");
            }


            // others PART
            // ----------------------------------------------------------

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
                string studioId = GetId("select id from tbl_studios where name like '" + pStudio_name + "'", pPostgres);
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