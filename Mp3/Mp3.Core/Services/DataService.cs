//using System.Collections.Generic;
//using MvvmCross.Platform;
//using MvvmCross.Plugins.Sqlite;
//using SQLite.Net;
//using SQLite;
//using System.Collections.Generic;
//using System.Linq;
//using SQLite.Net.Async;


//namespace Mp3.Core.Services
//{
//    public class DataService : IDataService
//    {
//        public List<DataMusic> GetMusics()
//        {
//            return database.Table<DataMusic>().ToList();
//        }

//        SQLiteConnection database;

//        public DataService(IMvxSqliteConnectionFactory factory)
//        {
//            database = factory.GetConnection("dbMusics.sql");
            
//            database.CreateTable<DataMusic>();
//        }

//    }
//}
