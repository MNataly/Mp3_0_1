using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Mp3.Core.Services
{
    public class DataService : IDataService
    {
        private readonly SQLiteConnection _sqLiteConnection;
        
        public DataService(IMvxSqliteConnectionFactory sqliteConnectionFactory)
        {
            var databaseName = "dbMusic.sqlite";
            _sqLiteConnection = sqliteConnectionFactory.GetConnection(databaseName);
            _sqLiteConnection.CreateTable<DataMusic>();
            
        }


        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public List<DataMusic> GetMusics()
        {
            return _sqLiteConnection.Table<DataMusic>().ToList();
        }

        
        public int Insert(DataMusic dataMusic)
        {
            return _sqLiteConnection.Insert(dataMusic);
        }

        public int InsertAll(List<DataMusic> dataMusics)
        {
            return _sqLiteConnection.UpdateAll(dataMusics);
        }

        public int Update(DataMusic dataMusic)
        {
            return _sqLiteConnection.Update(dataMusic);
        }

        public int UpdateAll(List<DataMusic> dataMusics)
        {
            return _sqLiteConnection.UpdateAll(dataMusics);
        }

        public int Delete(DataMusic dataMusic)
        {
            return _sqLiteConnection.Delete<DataMusic>(dataMusic.Id);
        }

        public int DeleteAll()
        {
             return _sqLiteConnection.DeleteAll<DataMusic>();
        }
    }
}
