using System;
using System.Linq;
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

        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
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
    }
}