using System.Collections.Generic;
using SQLite.Net;

namespace Mp3.Core.Services
{
    public interface IDataService 
    {
        List<DataMusic> GetMusics();
        int Insert(DataMusic dataMusic);
        int InsertAll(List<DataMusic> dataMusics);
        int Update(DataMusic dataMusic);
        int UpdateAll(List<DataMusic> dataMusics);
        int Delete(DataMusic dataMusic);

        int DeleteAll();
    }
}
