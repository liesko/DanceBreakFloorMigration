using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tda_award_nominations : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_tda_award_nominations");
            pMysql.Message = "tbl_tda_award_nominations - extraction - START ";
            while (dataReader.Read())
            {
                string pDesigner = "0";
                if (!String.IsNullOrEmpty(dataReader["sa_oacd_designer"].ToString()))
                {
                    pDesigner = AddNewPerson(dataReader["sa_oacd_designer"].ToString(), pPostgres);
                }

                pPostgres.Insert("insert into tbl_tda_award_nominations(id, studios_id, tour_dates_id, has_soty, soty_ts_ballet_routineid, " +
                                 "soty_ts_jazz_routineid, soty_ts_musicaltheater_routineid, soty_ts_contemplyrical_routineid, soty_ts_hiphoptap_routineid, " +
                                 "soty_mj_ballet_routineid, soty_mj_jazz_routineid, soty_mj_musicaltheater_routineid, soty_mj_contemplyrical_routineid, " +
                                 "soty_mj_hiphoptap_routineid, sa_ts_ota_routineid, sa_ts_ota_no, sa_mj_ota_routineid, sa_mj_ota_no, sa_oacd_routineid, " +
                                 "tbl_person_id_designer, sa_oacd_no, sa_ts_bc_routineid, sa_ts_bc_no, sa_mj_bc_routineid, sa_mj_bc_no, sa_peopleschoice_no, " +
                                 "sa_peopleschoice_routineid, sa_s_ota_routineid, sa_s_ota_no, sa_t_ota_routineid, sa_t_ota_no, sa_j_ota_routineid, " +
                                 "sa_j_ota_no, sa_m_ota_routineid, sa_m_ota_no) " +
                                 "values(" + dataReader["id"] + "," + dataReader["studioid"] + "," + dataReader["tourdateid"] + "," +
                                 "" + CheckBool(dataReader["has_soty"].ToString()) + "," + NVL(dataReader["soty_ts_ballet_routineid"].ToString()) + "," + NVL(dataReader["soty_ts_jazz_routineid"].ToString()) + "," +
                                 "" + NVL(dataReader["soty_ts_musicaltheater_routineid"].ToString()) + "," + NVL(dataReader["soty_ts_contemplyrical_routineid"].ToString()) + "," +
                                 "" + NVL(dataReader["soty_ts_hiphoptap_routineid"].ToString()) + "," + NVL(dataReader["soty_mj_ballet_routineid"].ToString()) + "," + NVL(dataReader["soty_mj_jazz_routineid"].ToString()) + "," +
                                 "" + NVL(dataReader["soty_mj_musicaltheater_routineid"].ToString()) + "," + NVL(dataReader["soty_mj_contemplyrical_routineid"].ToString()) + "," +
                                 "" + NVL(dataReader["soty_mj_hiphoptap_routineid"].ToString()) + "," + NVL(dataReader["sa_ts_ota_routineid"].ToString()) + "," + CheckBool(dataReader["sa_ts_ota_no"].ToString()) + "," +
                                 "" + NVL(dataReader["sa_mj_ota_routineid"].ToString()) + "," + CheckBool(dataReader["sa_mj_ota_no"].ToString()) + "," + NVL(dataReader["sa_oacd_routineid"].ToString()) + "," +
                                 "" + pDesigner + "," + CheckBool(dataReader["sa_oacd_no"].ToString()) + "," + NVL(dataReader["sa_ts_bc_routineid"].ToString()) + "," +
                                 "" + CheckBool(dataReader["sa_ts_bc_no"].ToString()) + "," + NVL(dataReader["sa_mj_bc_routineid"].ToString()) + "," + CheckBool(dataReader["sa_mj_bc_no"].ToString()) + "," + CheckBool(dataReader["sa_peopleschoice_no"].ToString()) + "," +
                                 "" + NVL(dataReader["sa_peopleschoice_routineid"].ToString()) + "," + NVL(dataReader["sa_s_ota_routineid"].ToString()) + "," + CheckBool(dataReader["sa_s_ota_no"].ToString()) + "," +
                                 "" + NVL(dataReader["sa_t_ota_routineid"].ToString()) + "," + CheckBool(dataReader["sa_t_ota_no"].ToString()) + "," + NVL(dataReader["sa_j_ota_routineid"].ToString()) + "," +CheckBool(dataReader["sa_j_ota_no"].ToString()) + "," +
                                 "" + NVL(dataReader["sa_m_ota_routineid"].ToString()) + "," + CheckBool(dataReader["sa_m_ota_no"].ToString()) + ");");
                // insert on M:N table
                string pTeacher = "0";
                if (!String.IsNullOrEmpty(dataReader["sa_ts_bc_choreographer"].ToString()))
                {
                    pTeacher = AddNewPerson(dataReader["sa_ts_bc_choreographer"].ToString(), pPostgres);
                    Add_award_nominations_has_teacher(pTeacher, dataReader["id"].ToString(),pPostgres);
                }
                if (!String.IsNullOrEmpty(dataReader["sa_mj_bc_choreographer"].ToString()))
                {
                    pTeacher = AddNewPerson(dataReader["sa_mj_bc_choreographer"].ToString(), pPostgres);
                    Add_award_nominations_has_teacher(pTeacher, dataReader["id"].ToString(), pPostgres);
                }
            }

            pPostgres.Message = "tbl_tda_award_nominations - extraction - FINISH";
        }
        public string AddNewPerson(string pName,  PostgreSQL_DB pPostgres)
        {
            string PersonType = GetId("select id from tbl_person_types where name like 'Costume Designer' limit 1;", pPostgres);
            pPostgres.Insert("insert into tbl_person(fname, person_types_id) " +
                                 "values('" + pName.ToString().Replace("'", "''") + "',"+ PersonType + ")");
            string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);            
            return Max_person_id;
        }
        public string AddNewPersonTeacher(string pName, PostgreSQL_DB pPostgres)
        {
            string PersonType = GetId("select id from tbl_person_types where name like 'Teacher' limit 1;", pPostgres);
            pPostgres.Insert("insert into tbl_person(fname, person_types_id) " +
                                 "values('" + pName.ToString().Replace("'", "''") + "'," + PersonType + ")");
            string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);
            return Max_person_id;
        }

        public void Add_award_nominations_has_teacher(string pPersonId, string pAwardId, PostgreSQL_DB pPostgres)
        {
            pPostgres.Insert("insert into tbl_award_nominations_has_teacher(tbl_person_id, tbl_tda_award_nominations_id) " +
                             "values("+pPersonId+","+pAwardId+")");        
        }
    }    
}