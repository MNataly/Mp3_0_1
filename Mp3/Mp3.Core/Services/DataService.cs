using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Mp3.Core.Services
{
    public class DataService : IDataService
    {
        private readonly  IMvxSqliteConnectionFactory _sqliteConnectionFactory;

        public List<DataMusic> GetMusics()
        {
            return null;//database.Table<DataMusic>().ToList();
        }

        public void Insert(DataMusic dataMusic)
        {
            throw new System.NotImplementedException();
        }


        public DataService()
        {
            //IMvxSqliteConnectionFactory sqliteConnectionFactory;
            //_sqliteConnectionFactory = sqliteConnectionFactory;
            //var databaseName = "dbMusic.sqlite";
            //var connection = _sqliteConnectionFactory.GetConnection(databaseName);
            //connection.CreateTable<DataMusic>();
            createConnection();
        }

        private void createConnection()
        {
            var databaseName = "dbMusic.sqlite";
            //TestDb db = new TestDb(new SQLitePlatformTest(),databaseName);
        }


        
    }

    public class TestDb : SQLiteConnection
    {
        public TestDb(ISQLitePlatform sqlitePlatform, String path)
            : base(sqlitePlatform, path)
        {
            TraceListener = DebugTraceListener.Instance;
            CreateTable<DataMusic>();
        }
    }
}
