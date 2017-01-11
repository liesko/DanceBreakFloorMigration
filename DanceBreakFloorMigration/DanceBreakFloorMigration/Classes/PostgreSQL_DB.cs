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
        private NpgsqlTransaction _tran;

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
        public PostgreSQL_DB(string pDBName, string pServer, string pUid, string pPort, string pPassword, Form1 form)
        {
            Initialize(pDBName, pServer,pUid,pPort,pPassword);
            _form = form;
        }
        private void Initialize(string pDBName, string pServer, string pUid, string pPort, string pPassword)
        {

            //server = "localhost";
            server = pServer;
            database = pDBName;
            // uid = "postgres";
            //uid = "peterkim";
            uid = pUid;
            //port = "5432";
            port = pPort;
            //password = "peterkim";
            password = pPassword;
            // password = "ahojahoj";
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
                //_tran = connection.BeginTransaction();
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
            try
            {
                _tran = connection.BeginTransaction();
                cmd.CommandText = pInsertString;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                _tran.Commit();
            }
            catch (Exception)
            {
                Message = "Invalid insert: "+ pInsertString;
                _tran.Dispose();
            }
        }

        public void Delete(string pTableName)
        {
            cmd.CommandText = "delete from " + pTableName + ";";
            Message = "DELETED: " + pTableName;
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public void Update(string pUpdate)
        {
            cmd.CommandText = pUpdate;
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public NpgsqlDataReader Select(string pQuery)
        {
            cmd.CommandText = pQuery;
            cmd.Connection = connection;
            NpgsqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}