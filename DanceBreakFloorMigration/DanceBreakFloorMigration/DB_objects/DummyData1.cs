using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.Classes
{
    public class DummyData1 : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            pMysql.Message = "DUMMY data1 GENERATE - START";
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(36, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(64, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(119, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(120, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(121, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(122, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(152, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(157, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(165, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(195, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(196, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(197, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(198, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(199, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(200, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(219, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(307, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(324, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(358, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(432, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(436, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(437, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(502, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(503, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(534, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(535, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(536, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(537, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(538, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(539, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(540, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(541, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(542, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(543, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(545, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(546, 1,6);");
            pPostgres.Insert("insert into tbl_tour_dates(id, season_id, event_id) values(580, 1,6);");
            pMysql.Message = "DUMMY data1 GENERATE - FINISH";
        }
    }
}