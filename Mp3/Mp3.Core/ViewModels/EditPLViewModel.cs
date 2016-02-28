using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Mp3.Core.ViewModels
{
    public class EditPLViewModel :MvxViewModel
    {
        private readonly IDataService _dataService;
        private readonly IPlayListsService _playListsService;
        PlayList CurrentPL = new PlayList(); 
        public EditPLViewModel(IDataService dataService, IPlayListsService playListsService)
        {
            _dataService = dataService;
            _playListsService = playListsService;

            _listSongs = _dataService.GetMusics();
            _playLists = _playListsService.GetPlayLists();
        }

        public void Init(PlayList playList)
        {
            CurrentPL = PlayLists.Find(bk => bk.IdPL == playList.IdPL);

            string[] idStrings = CurrentPL.ListMusicsId.Split(' ');
            //ListSongs = new List<DataMusic>();
            foreach (var item in idStrings)
            {
                
                if (item != "")
                
                {
                    
                    ListSongs.Find(bk => bk.Id == Convert.ToInt32(item)).IsChecked = true;
                }
            }
            
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
            set { _playLists = value; RaisePropertyChanged(() => PlayLists); }
        }

        private List<PlayList> _playLists;

        public PlayList UpdatePList
        {
            get { return _updatePList; }
            set { _updatePList = value; RaisePropertyChanged(() => UpdatePList); }
        }

        private PlayList _updatePList;

        private void UpdatePL()
        {

            CurrentPL.ListMusicsId = null;
            foreach (var item in ListSongs)
            {
                if (item.IsChecked)
                {
                    CurrentPL.ListMusicsId += item.Id.ToString() + " ";
                }

            }

            _playListsService.Update(CurrentPL);
            ShowViewModel<PLViewModel>(new PlayList()
            {
                IdPL = CurrentPL.IdPL
            });
        }

        public ICommand SavePLCommand
        {
            get { return new MvxCommand(() =>
            {
                UpdatePL();
                Close(this);
            }); }
        }
    }
}
