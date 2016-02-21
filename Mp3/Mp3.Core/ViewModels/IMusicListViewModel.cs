using System.Collections.Generic;
using Mp3.Core.Services;

namespace Mp3.Core.ViewModels
{
    public interface IMusicListViewModel
    {
        List<DataMusic> GetListMusic();
    }
}
