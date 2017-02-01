using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_routine_categories : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select cast(name as char) name, min_dancers, full_fee_per_dancer, duration, cast(abbreviation as char) abbreviation, discount_fee_per_dancer, " +
                                                       "finale_fee_per_dancer, finale_prelim_fee_per_dancer from tbl_routine_categories_11;");

            pMysql.Message = "tbl_routine_categories - extraction - START";
            while (dataReader.Read())
            {
                string categId = GetId("select id from tbl_category where lower(name) like lower('" + dataReader["name"]+ "');", pPostgres);
                pPostgres.Insert("insert into tbl_routine_categories(season_id, category_id, min_dancers, full_fee_per_dancer, duration, abbreviation, discount_fee_per_dancer, " +
                                 "finale_fee_per_dancer, finale_prelim_fee_per_dancer) " +
                                 "values('11','"+categId+"','"+dataReader["min_dancers"] + "','" + dataReader["full_fee_per_dancer"] + "','" + dataReader["duration"] + "'," +
                                 "'" + dataReader["abbreviation"] + "','" + dataReader["discount_fee_per_dancer"] + "','" + dataReader["finale_fee_per_dancer"] + "','" + dataReader["finale_prelim_fee_per_dancer"] + "')");
            }
            dataReader = pMysql.Select("select cast(name as char) name, min_dancers, full_fee_per_dancer, duration, cast(abbreviation as char) abbreviation, discount_fee_per_dancer, " +
                                                       "finale_fee_per_dancer, finale_prelim_fee_per_dancer from tbl_routine_categories_14;");
            while (dataReader.Read())
            {
                string categId = GetId("select id from tbl_category where lower(name) like lower('" + dataReader["name"] + "');", pPostgres);
                pPostgres.Insert("insert into tbl_routine_categories(season_id, category_id, min_dancers, full_fee_per_dancer, duration, abbreviation, discount_fee_per_dancer, " +
                                 "finale_fee_per_dancer, finale_prelim_fee_per_dancer) " +
                                 "values('14','" + categId + "','" + dataReader["min_dancers"] + "','" + dataReader["full_fee_per_dancer"] + "','" + dataReader["duration"] + "'," +
                                 "'" + dataReader["abbreviation"] + "','" + dataReader["discount_fee_per_dancer"] + "','" + dataReader["finale_fee_per_dancer"] + "','" + dataReader["finale_prelim_fee_per_dancer"] + "')");
            }
            dataReader = pMysql.Select("select cast(name as char) name, min_dancers, full_fee_per_dancer, duration, cast(abbreviation as char) abbreviation, discount_fee_per_dancer, " +
                                                       "finale_fee_per_dancer, finale_prelim_fee_per_dancer from tbl_routine_categories_17;");
            while (dataReader.Read())
            {
                string categId = GetId("select id from tbl_category where lower(name) like lower('" + dataReader["name"] + "');", pPostgres);
                pPostgres.Insert("insert into tbl_routine_categories(season_id, category_id, min_dancers, full_fee_per_dancer, duration, abbreviation, discount_fee_per_dancer, " +
                                 "finale_fee_per_dancer, finale_prelim_fee_per_dancer) " +
                                 "values('17','" + categId + "','" + dataReader["min_dancers"] + "','" + dataReader["full_fee_per_dancer"] + "','" + dataReader["duration"] + "'," +
                                 "'" + dataReader["abbreviation"] + "','" + dataReader["discount_fee_per_dancer"] + "','" + dataReader["finale_fee_per_dancer"] + "','" + dataReader["finale_prelim_fee_per_dancer"] + "')");
            }
            dataReader = pMysql.Select("select cast(name as char) name, min_dancers, full_fee_per_dancer, duration, cast(abbreviation as char) abbreviation, discount_fee_per_dancer, " +
                                                       "finale_fee_per_dancer, finale_prelim_fee_per_dancer from tbl_routine_categories_2;");
            while (dataReader.Read())
            {
                string categId = GetId("select id from tbl_category where lower(name) like lower('" + dataReader["name"] + "');", pPostgres);
                pPostgres.Insert("insert into tbl_routine_categories(season_id, category_id, min_dancers, full_fee_per_dancer, duration, abbreviation, discount_fee_per_dancer, " +
                                 "finale_fee_per_dancer, finale_prelim_fee_per_dancer) " +
                                 "values('2','" + categId + "','" + dataReader["min_dancers"] + "','" + dataReader["full_fee_per_dancer"] + "','" + dataReader["duration"] + "'," +
                                 "'" + dataReader["abbreviation"] + "','" + dataReader["discount_fee_per_dancer"] + "','" + dataReader["finale_fee_per_dancer"] + "','" + dataReader["finale_prelim_fee_per_dancer"] + "')");
            }
            dataReader = pMysql.Select("select cast(name as char) name, min_dancers, full_fee_per_dancer, duration, cast(abbreviation as char) abbreviation, discount_fee_per_dancer, " +
                                                       "finale_fee_per_dancer, finale_prelim_fee_per_dancer from tbl_routine_categories_20;");
            while (dataReader.Read())
            {
                string categId = GetId("select id from tbl_category where lower(name) like lower('" + dataReader["name"] + "');", pPostgres);
                pPostgres.Insert("insert into tbl_routine_categories(season_id, category_id, min_dancers, full_fee_per_dancer, duration, abbreviation, discount_fee_per_dancer, " +
                                 "finale_fee_per_dancer, finale_prelim_fee_per_dancer) " +
                                 "values('20','" + categId + "','" + dataReader["min_dancers"] + "','" + dataReader["full_fee_per_dancer"] + "','" + dataReader["duration"] + "'," +
                                 "'" + dataReader["abbreviation"] + "','" + dataReader["discount_fee_per_dancer"] + "','" + dataReader["finale_fee_per_dancer"] + "','" + dataReader["finale_prelim_fee_per_dancer"] + "')");
            }
            dataReader = pMysql.Select("select cast(name as char) name, min_dancers, full_fee_per_dancer, duration, cast(abbreviation as char) abbreviation, discount_fee_per_dancer, " +
                                                       "finale_fee_per_dancer, finale_prelim_fee_per_dancer from tbl_routine_categories_22;");
            while (dataReader.Read())
            {
                string categId = GetId("select id from tbl_category where lower(name) like lower('" + dataReader["name"] + "');", pPostgres);
                pPostgres.Insert("insert into tbl_routine_categories(season_id, category_id, min_dancers, full_fee_per_dancer, duration, abbreviation, discount_fee_per_dancer, " +
                                 "finale_fee_per_dancer, finale_prelim_fee_per_dancer) " +
                                 "values('22','" + categId + "','" + dataReader["min_dancers"] + "','" + dataReader["full_fee_per_dancer"] + "','" + dataReader["duration"] + "'," +
                                 "'" + dataReader["abbreviation"] + "','" + dataReader["discount_fee_per_dancer"] + "','" + dataReader["finale_fee_per_dancer"] + "','" + dataReader["finale_prelim_fee_per_dancer"] + "')");
            }

            pPostgres.Message = "tbl_routine_categories - extraction - FINISH";
        }
    }
}