
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Input;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Mp3.Core.ViewModels
{
    public class PLViewModel : MvxViewModel
    {

        private readonly IPlayListsService _playListsService;
        private readonly IDataService _dataService;
        public PlayList PList = new PlayList();

        public PLViewModel(IPlayListsService playListsService, IDataService dataService)
        {
            _playListsService = playListsService;
            _dataService = dataService;
            PlayLists = _playListsService.GetPlayLists();
            ListAllSongs = _dataService.GetMusics();
        }

        public void Init(PlayList playList)
        {
            PList = PlayLists.Find(bk => bk.IdPL == playList.IdPL);

            string[] idStrings = PList.ListMusicsId.Split(' ');
            ListSongs = new List<DataMusic>();
            foreach (var i in idStrings)
            {
                if (i != "")
                {
                    int x = Convert.ToInt32(i);
                    ListSongs.Add(ListAllSongs.Find(bk => bk.Id == x));
                }
            }
            //_listSongs = PL.ListMusicsId as List<int>;
        }
        private List<DataMusic> _listAllSongs;

        public List<DataMusic> ListAllSongs
        {
            get { return _listAllSongs; }
            set { _listAllSongs = value; RaisePropertyChanged(() => ListAllSongs); }
        }


        private List<DataMusic> _listSongs;

        public List<DataMusic> ListSongs
        {
            get { return _listSongs; }
            set { _listSongs = value; RaisePropertyChanged(() => ListSongs); }
        }
        public List<PlayList> PlayLists
        {
            get { return _playLists; }
            set { _playLists = value; RaisePropertyChanged(()=>PlayLists);}
        }

        private List<PlayList> _playLists;

        public ICommand EditPLCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<EditPLViewModel>
                (new PlayList()
                {
                    IdPL = PList.IdPL
                }));
               
            }
        }

        public ICommand DeletePLCommand
        {
            get { return new MvxCommand(() => DoDeletePL()); }
        }

        private void DoDeletePL()
        {
            _playListsService.Delete(PList);
            ShowViewModel<PLsViewModel>();
        }
        public ICommand TapItemPlayCommand
        {
            get
            {
                return new MvxCommand<DataMusic>((item) => ShowViewModel<PlayerViewModel>(new { IdDataMusic = item.Id, IdPList = PList.IdPL }
                    ));
            }
        }

    }
}
