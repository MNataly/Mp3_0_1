using System.Collections.Generic;
using SQLite.Net;

namespace Mp3.Core.Services
{
    public interface IDataService 
    {
        List<DataMusic> GetMusics();
       
        
    }
}
