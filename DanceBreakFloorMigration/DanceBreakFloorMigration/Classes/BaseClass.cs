using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.Classes
{
    public class BaseClass
    {
        public string GetId(string pParam, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select(pParam);
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return pom;
            }
            query.Dispose();
            return "null";
        }

        public int CheckBool(string pValue)
        {
            if (pValue == "True")
            {
                return 1;
            }
            return 0;
        }

        public static string Remove(string source, char[] oldChar)
        {
            return String.Join("", source.ToCharArray().Where(a => !oldChar.Contains(a)).ToArray());
        }

        //public DateTime FromUnixTime(long unixTime)
        public static string FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToString();
        }

        public string NVL(string pParam)
        {
            if (pParam == "")
            {
                return "null";
            }
            return "'" + pParam + "'";
        }

        public string AddNewStudio(string pStudioName, PostgreSQL_DB pPostgres)
        {
            int MaxStudioId = Convert.ToInt32(GetId("select max(id) from tbl_studios;", pPostgres));
            pPostgres.Insert("insert into tbl_studios(id, name) values('" + ++MaxStudioId + "','"+pStudioName+"')");
            return MaxStudioId.ToString();
        }
        public void CreateDummyWaiver(string pWaiverId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_waivers where id = " + pWaiverId + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_waivers(id, dancer_id) values(" + pWaiverId + ", 20797);");
            }
        }
        public void CreateDummyStudio(string pStudio, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_studios where id = " + pStudio + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_studios(id, name) values(" + pStudio + ",'DUMMY DANCE STUDIO');");
            }
        }
        public void CreateDummyRegistration(string pRegistration, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_registration where id = " + pRegistration + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_registration(id) values(" + pRegistration + ");");
            }
        }
        public void CreateDummyWorkshopLevel(string pWorkshopLevel, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_workshop_levels where id = " + pWorkshopLevel + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_workshop_levels(id, playlist_workshop_levels_id, season_id) values(" + pWorkshopLevel + ",0,0);");
            }
        }
        public void CreateDummyDancer(string pDancerId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_dancer where id = " + pDancerId + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_dancer(id, person_id) values(" + pDancerId + ",0);");
            }
        }
        public void CreateDummyPromoCode(string pPromoCode, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_promo_codes where id = " + pPromoCode + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_promo_codes(id, promo_codes_type_id, name,uses) values(" + pPromoCode + ",1, 'DUMMY',1);");
            }
        }
        public void CreateDummyRoutines(string pRoutineId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_routines where id = " + pRoutineId + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_routines(id, studios_id, name) values("+ pRoutineId + ", 0, 'DUMMY');");
            }
        }
        public void CreateDummyFaculty(string pFacultyId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_faculty where id = " + pFacultyId + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values("+ pFacultyId + ",6,20797, 'DUMMY', 'DUMMY');");
            }
        }
        public void CreateDummyTblDateDancers(string pTblDateDancersId, PostgreSQL_DB pPostgres)
        {
            string check = GetId("select id from tbl_date_dancers where id = " + pTblDateDancersId + ";", pPostgres);
            if (check == "null")
            {
                pPostgres.Insert("insert into tbl_date_dancers(id) values("+ pTblDateDancersId + ");");
            }
        }

        /* 
         * pId - ID in MySQL table
         * pMysqlList - first is Table_name or "null", others are ROWS
         * pPosgresList - first is Table_name others are rows
         * condition: count and order of the rows must be the same
         */

        public void UpdatePostgreRow(String pId, List<String> pMysqlList, List<String> pPosgresList, PostgreSQL_DB pPostgres)
        {                        
                string core_update_string = null;
                for (int i = 1; i < pMysqlList.Count; i++)
                {
                    core_update_string += pPosgresList[i];
                    core_update_string += "=";
                    String pMysqlValue = null;
                    if (pMysqlList[i]=="False" || pMysqlList[i] == "True")
                    {
                        pMysqlValue = pMysqlList[i].Replace("False","0").Replace("True","1");
                    }
                    else
                    {
                        pMysqlValue = pMysqlList[i];
                    }

                    core_update_string += "'"+ pMysqlValue.Replace("'","''") + "'";
                    if (i< pMysqlList.Count-1)
                    {
                        core_update_string += ", ";
                    }                    
                }
                pPostgres.Update("update "+pPosgresList[0]+ " set "+ core_update_string + " where id="+pId+";");
        }
        /*
         * Method - return number of second from string
         * example: RetSeconds("0:30")
         */
        public string RetSeconds(string ptime)
        {
            String time = ptime;
            time = "0:" + time;
            TimeSpan ts = TimeSpan.Parse(time);
            double totalSeconds = ts.TotalSeconds;
            return totalSeconds.ToString();
        }
        /*
         * Method will remove firs two occurence of selected char
         * example: RemoveFirstTwoOccurence(" ","10. 10. 2010 30:30:30") --->10.10.2010 30:30:30
         */
        public static string RemoveFirstTwoOccurence(string pRemove, string pString)
        {
            string newtring = pString;
            int index = newtring.IndexOf(pRemove);
            string cleanPath = (index < 0)
                ? newtring
                : newtring.Remove(index, pRemove.Length);

            newtring = cleanPath;
            index = newtring.IndexOf(pRemove);
            cleanPath = (index < 0)
                ? newtring
                : newtring.Remove(index, pRemove.Length);

            return cleanPath;
        }
        /*
         * will return time from datetime
         * example: ReturnTimeFromDateTime("25. 9. 2010 8:00:01")   ----> 8:00:01
         */
        public static string ReturnTimeFromDateTime(string pDateTime)
        {
            DateTime pom_date = Convert.ToDateTime(pDateTime);
            return pom_date.TimeOfDay.ToString();
        }
    }
}