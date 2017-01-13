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
    }
}