using System.Collections.Generic;

namespace Mp3.Core.Services
{
    public class DataService : IDataService
    {
        public List<DataMusic> GetMusics()
        {
            return null;//database.Table<DataMusic>().ToList();
        }


        public DataService()
        {
        }
    }
}
