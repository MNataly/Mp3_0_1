using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Mp3.Core.ViewModels
{
    public class AddPlayListViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;

        public AddPlayListViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataMusics = _dataService.GetMusics();
        }

        private List<DataMusic> _dataMusics;

        public List<DataMusic> ListSongs
        {
            get { return _dataMusics; }
            set { _dataMusics = value; RaisePropertyChanged(() => ListSongs); }
        }
    }
}
