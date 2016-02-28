using System.Collections.Generic;
using System.Windows.Input;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Mp3.Core.ViewModels
{
    public class MusicListViewModel : MvxViewModel
    {
        private List<DataMusic> _listSongs;

        public List<DataMusic> ListSongs
        {
            get { return _listSongs; }
            set
            {
                _listSongs = value;
                RaisePropertyChanged(() => ListSongs);
            }
        }

        private readonly IDataService _dataService;


        public MusicListViewModel(IDataService dataService)
        {
            _dataService = dataService;
            
            int test = _dataService.X;
            //DoList();
            //DelAll();
            ListSongs = _dataService.GetMusics();
            if (ListSongs.Count == 0)
            {
                //_dataService.DeleteAll();
                DoList();
                ListSongs = _dataService.GetMusics();
            }
        }


        private List<DataMusic> _dataMusics;

        public List<DataMusic> DataMusics
        {
            get { return _dataMusics; }
            set
            {
                _dataMusics = value;
                RaisePropertyChanged(() => DataMusics);
            }
        }

        

        private void DoList()
        {
            var listServise = Mvx.Resolve<ISoungsManagerService>();

            DataMusics = listServise.getPlayList;
            foreach (var t in DataMusics)
            {
                int i = _dataService.Insert(t);
            }
        }

        public ICommand TapItemMusicCommand
        {
            get
            {
                return
                    new MvxCommand<DataMusic>((item) =>
                    {
                        ShowViewModel<PlayerViewModel>(new
                        {
                            IdDataMusic = item.Id,
                            IdPList = -1
                        }
                            );
                        Close(this);
                    });
            }
        }
    }
}
