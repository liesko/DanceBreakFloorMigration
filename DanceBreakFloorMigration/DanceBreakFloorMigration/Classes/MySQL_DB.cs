using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Classes
{
    public class MySQL_DB:IDB
    {
        private Form1 _form;
        private string _message;
        private MySqlCommand _cmd = new MySqlCommand();
        private MySqlDataReader _dataReader;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                _form.MyEvent.Invoke(null, new HandlerArgs { Message = _message });
            }
        }
        private MySqlConnection connection;
        private string server;
        public string database { get; private set; }
        private string uid;
        private string password;
        public MySQL_DB(String pDBName, string pServer, string pUid, string pPassword, Form1 form)
        {
            Initialize(pDBName, pServer, pUid, pPassword);
            _form = form;
        }

        private void Initialize(String pDBName, string pServer, string pUid, string pPassword)
        {

           // server = "localhost";
            server = pServer;
            database = pDBName;
            //uid = "root";
            uid = pUid;
            //password = "ahojahoj";
            password = pPassword;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                Message = "MySQL DB: " + database + " - connected successfully.";
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Message = "MySQL DB: " + database + " - CONNECT FAILE.";
                switch (ex.Number)
                {
                    case 0:
                        Message = "MySQL DB: " + database + " - CONNECT FAILE. Cannot connect to server.";
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Message = "MySQL DB: " + database + " - CONNECT FAILE. Invalid username/password, please try again";
                        // MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(string pInsertString)
        {
            string query = "INSERT INTO table...";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(string pUpdate)
        {
            throw new NotImplementedException();
        }

        public MySqlDataReader Select(String pQuery)
        {
            _cmd.CommandText = pQuery;
            _cmd.Connection = connection;
            if(_dataReader?.IsClosed==false)
                _dataReader.Close();
            _dataReader = _cmd.ExecuteReader();
            return _dataReader;
        }
    }
}