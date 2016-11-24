using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.Classes
{
    public class PostgreSQL_DB : IDB
    {
        private NpgsqlConnection connection;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private string server;

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                _form.MyEvent.Invoke(null, new HandlerArgs { Message = _message });
            }
        }
        public string database { get; set; }
        private string uid;
        private string port;
        private string password;
        private Form1 _form;
        public PostgreSQL_DB(string pDBName, Form1 form)
        {
            Initialize(pDBName);
            _form = form;
        }
        private void Initialize(string pDBName)
        {

            server = "localhost";
            database = pDBName;
            uid = "postgres";
            port = "5432";
            password = "ahojahoj";
            string connectionString;
            connectionString = "Server=" + server + ";"
                + "Port=" + port + ";"
                + "User Id=" + uid + ";"
                + "Password=" + password + ";"
                + "Database=" + database + ";";
            connection = new NpgsqlConnection(String.Format(connectionString));
        }
        public bool OpenConnection()
        {
            try
            {
                Message = "Postgresql DB: "+database+ " - connected successfully.";
                connection.Open();
                return true;
            }
            catch (NpgsqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.ErrorCode)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            throw new System.NotImplementedException();
        }

        public void Insert(string pInsertString)
        {
            cmd.CommandText = pInsertString;
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public void Delete(string pTableName)
        {
            cmd.CommandText = "delete from " + pTableName + ";";
            Message = "DELETED: " + pTableName;
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public MySqlDataReader Select(string pQuery)
        {
            throw new NotImplementedException();
        }
    }
}