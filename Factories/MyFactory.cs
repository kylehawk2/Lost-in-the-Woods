using System.Collections.Generic;
using System.Data;
using LostintheWoods.Models;
using Dapper;
using System.Linq;
using System;
using MySql.Data.MySqlClient;

namespace LostintheWoods.Factory
{

    public class TrailFactory
    {
        
        static string server = "localhost";
        static string db = "trails"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }


        public IEnumerable<AllTrails> AllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                 IEnumerable<AllTrails> result =  Connection.Query<AllTrails>($@"SELECT * FROM trails");
                return Connection.Query<AllTrails>($@"SELECT * FROM trails");;
            }
        }
        public bool TrailExists(string trails)
        {
            string sql = $@"SELECT * FROM trails WHERE trails = @weirdName";
            object preventSQLInjection = new {weirdName = trails};

             using(IDbConnection dbConnection = Connection)
             {
                IEnumerable<AllTrails> result =  Connection.Query<AllTrails>(sql, preventSQLInjection);
                int numtrails = result.Count();
                return numtrails >= 1;
            }
        }
        public void AddTrails(AllTrails item){
            using(IDbConnection dbConnection = Connection){
                string sql = $@"INSERT INTO trails(trail_name, description, length, elevation, latitude, longitude)VALUES(@trail_name, @description, @length, @elevation, @latitude, @longitude)";
                dbConnection.Open();
                dbConnection.Execute(sql, item);
            }
        }
        public IEnumerable<AllTrails> TrailInfo(string trails){
            using(IDbConnection dbConnection = Connection)
            {
                IEnumerable<AllTrails> result = Connection.Query<AllTrails>($@"SELECT * FROM trails WHERE trail_name = '{trails}'");
                return result;
            }
        }
    }
}