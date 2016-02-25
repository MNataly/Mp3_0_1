using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Core.Services
{
    public interface IPlayListsService
    {
        List<PlayList> GetPlayLists();


        int Insert(PlayList playList);
        int InsertAll(List<PlayList> playLists);
        int Update(PlayList playList);
        int UpdateAll(List<PlayList> playLists);
        int Delete(PlayList playList);

        int DeleteAll();
    }
}
