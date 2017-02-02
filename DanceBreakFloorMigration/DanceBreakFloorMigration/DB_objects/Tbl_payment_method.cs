using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_payment_method:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct payment_method from registrations where payment_method!='';");
            pMysql.Message = "payment_method (from registration)- extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_payment_method(id,name) values('"+ ++counter +"', '" + dataReader[0] + "')");
            }
            pPostgres.Message = "tbl_payment_method - extraction - FINISH";
            pPostgres.Update("update tbl_payment_method set name ='Credit cards' where name like 'credit_card'");
            pPostgres.Update("update tbl_payment_method set name ='Check' where name like 'check'");
            pPostgres.Update("update tbl_payment_method set name ='No Balance' where name like 'nobal'");
            pPostgres.Insert("insert into tbl_payment_method(id,name) values('"+ ++counter + "','Bank transfer')");
        }
    }
}