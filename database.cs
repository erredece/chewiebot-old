using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ChewieBot
{
    public partial class database
    {

        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=database.sqlite;Version=3;");

        internal void DBExists()
        {

            if (!File.Exists("database.sqlite"))
            {
                Console.WriteLine("DB file not existing, creating...");
                SQLiteConnection.CreateFile("database.sqlite");
            }
        }

        internal void CreateTable(string command)
        {
            m_dbConnection.Open();
            string sqlTable = $"create table if not exists {command})";
            SQLiteCommand createTableCommand = new SQLiteCommand(sqlTable, m_dbConnection);
            createTableCommand.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        internal void InsertValues(string command)
        {
            m_dbConnection.Open();
            string sql = $"insert into {command}";
            SQLiteCommand insertValue = new SQLiteCommand(sql, m_dbConnection);
            insertValue.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        internal void ReadValue(string table, string sort, string value)
        {
            m_dbConnection.Open();
            string sql = $"select * from {table} order by {sort}";
            SQLiteCommand readCommand = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader dbReader = readCommand.ExecuteReader();
            while (dbReader.Read())
            {
                Console.WriteLine($"Name: {dbReader[value]} - \tScore: {dbReader[sort]}");
            }
        }
    }
}