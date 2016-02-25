using System.Collections.Generic;
using System.Windows.Input;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Mp3.Core.ViewModels
{
    public class PlayListsViewModel : MvxViewModel
    {
        private readonly IPlayListsService _playListsService;

        public PlayListsViewModel(IPlayListsService playListsService)
        {
            _playListsService = playListsService;
            PlayLists = _playListsService.GetPlayLists();

        }

        private List<PlayList> _playLists;

        public List<PlayList> PlayLists
        {
            get { return _playLists; }
            set { _playLists = value; RaisePropertyChanged(() => PlayLists); }
        }

        private PlayList _playList;
        public PlayList PlayList
        {
            get { return _playList; }
            set { _playList = value; RaisePropertyChanged(() => PlayList); }
        }

        public ICommand AddPlayListCommand
        {
            get { return new MvxCommand(() => ShowViewModel<AddPlayListViewModel>()); }

        }

    }
}
