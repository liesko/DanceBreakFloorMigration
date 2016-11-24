using DanceBreakFloorMigration.DB_objects;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Classes
{
    public class Controller
    {
        public static MySQL_DB DanceteaManager; 
        public static MySQL_DB Mybreak_db;
        public static PostgreSQL_DB Pgdbbreakthefloor;
        private Form1 _form;
        public Controller(Form1 form)
        {
            _form = form;
            Pgdbbreakthefloor =  new PostgreSQL_DB("pgdbbreakthefloor", _form);
            DanceteaManager= new MySQL_DB("dancetea_manager", _form);
            Mybreak_db = new MySQL_DB("mybreak_db", _form);
        }
        public bool Connect()
        {
            if (DanceteaManager.OpenConnection() && Mybreak_db.OpenConnection() && Pgdbbreakthefloor.OpenConnection())
            {     
                return true;
            }
            return false;
        }

        public void Remigration()
        {
            DeleteTable("tbl_states");
            DeleteTable("tbl_gender");
            DeleteTable("tbl_store_colors");
            DeleteTable("tbl_person_types");
            DeleteTable("tbl_store_sizes");
            DeleteTable("tbl_store_product_types");
            DeleteTable("tbl_countries");

            Tbl_score_colors tab = new Tbl_score_colors();
            tab.Remigration(Mybreak_db, Pgdbbreakthefloor);

            Tbl_gender tab1 = new Tbl_gender();
            tab1.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_person_types tab2 = new Tbl_person_types();
            tab2.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_store_size tab3 = new Tbl_store_size();
            tab3.Remigration(Mybreak_db, Pgdbbreakthefloor);

            Tbl_store_product_type tab4 = new Tbl_store_product_type();
            tab4.Remigration(Mybreak_db, Pgdbbreakthefloor);

            Tbl_countries tab5 = new Tbl_countries();
            tab5.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_states tab6 = new Tbl_states();
            tab6.Remigration(DanceteaManager, Pgdbbreakthefloor);
        }
        private void DeleteTable(string pTableName)
        {
            Pgdbbreakthefloor.Delete(pTableName);
        }
    }
}