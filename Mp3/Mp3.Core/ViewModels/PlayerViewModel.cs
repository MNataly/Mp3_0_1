using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Mp3.Core.ViewModels
{
    public class PlayerViewModel : MvxViewModel
    {
        
        private IDataService _dataService;
        private IPlayListsService _playListsService;

        private bool IsPlayMusic;
        private bool NewPlaySong;

        

        public PlayerViewModel(IDataService dataService, IPlayListsService playListsService)
        {
           
            _dataService = dataService;
            _playListsService = playListsService;
            
            //_listAllSongs = _dataService.GetMusics();
            _pLists = playListsService.GetPlayLists();
            IsPlayMusic = false;
            NewPlaySong = true;


            //if (_listAllSongs.Count == 0)
            //{
                DoList();
                _listAllSongs = _dataService.GetMusics();
            //}

        }

        public void Init(int IdDataMusic, int IdPList)
        {
            if (IdDataMusic != 0 && IdPList != 0)
            {


                _item = _listAllSongs.Find(item => item.Id == IdDataMusic);
                if (IdPList != -1)
                {
                    _pList = _pLists.Find(item => item.IdPL == IdPList);
                    foreach (var item in PLists)
                    {
                        string[] idStrings = _pList.ListMusicsId.Split(' ');
                        _dataMusics = new List<DataMusic>();
                        foreach (var i in idStrings)
                        {
                            if (i != "")
                            {
                                int x = Convert.ToInt32(i);
                                _dataMusics.Add(_listAllSongs.Find(bk => bk.Id == x));
                            }
                        }
                    }

                }
                else
                {
                    _dataMusics = _listAllSongs;
                }

            }
            else
            {
                _item = _listAllSongs[0];
                _dataMusics = _listAllSongs;
                IsPlayMusic = false;
                NewPlaySong = true;
                MyResolve(_item);
            }

        }

        //public override void Start()
        //{
        //    base.Start();
        //    DoPlayCommand.Execute(null);
        //}
        private void DoList()
        {
            var listServise = Mvx.Resolve<ISoungsManagerService>();
            _dataService.DeleteAll();
            DataMusics = listServise.getPlayList;
            foreach (var t in DataMusics)
            {
                int i = _dataService.Insert(t);
            }
            
            
            
            //var listServise = Mvx.Resolve<ISoungsManagerService>();

            //DataMusics = listServise.getPlayList;
            //_dataService.DeleteAll();
            //_dataService.InsertAll(DataMusics);
            //foreach (var t in DataMusics)
            //{
            //    if (_listAllSongs.Find((bk) => bk.FilePath == t.FilePath)==null)
            //    {
            //        _dataService.Insert(t);
            //        _listAllSongs.Add(t);
            //    }

            //}
            //foreach (var t in _listAllSongs)
            //{
            //    if (DataMusics.Find((bk) => bk.FilePath == t.FilePath) == null)
            //    {
            //        _dataService.Delete(t);
            //        _listAllSongs.Remove(t);
            //    }
            //}
        }

        private PlayList _pList;
        private List<PlayList> _pLists;
        private DataMusic _item;
        private List<DataMusic> _dataMusics;
        private List<DataMusic> _listAllSongs;

        public PlayList PList
        {
            get { return _pList; }
            set { _pList = value; RaisePropertyChanged(() => PList); }
        }
        public List<PlayList> PLists
        {
            get { return _pLists; }
            set
            {
                _pLists = value;
                RaisePropertyChanged(() => PLists);
            }
        }
        public List<DataMusic> DataMusics
        {
            get { return _dataMusics; }
            set
            {
                _dataMusics = value;
                RaisePropertyChanged(() => DataMusics);
            }
        }
        public DataMusic Item
        {
            get { return _item; }
            set
            {
                _item = value;
                RaisePropertyChanged(() => Item);
            }
        }
        public List<DataMusic> ListAllSongs
        {
            get { return _listAllSongs; }
            set
            {
                _listAllSongs = value;
                RaisePropertyChanged(() => ListAllSongs);
            }
        }

        
        public void MyResolve(DataMusic dataMusic)
        {
  

            var messanger = Mvx.Resolve<IMvxMessenger>();
            var message = new MyMessageModel(this, dataMusic.Id, IsPlayMusic, NewPlaySong, _dataMusics);
            messanger.Publish(message);
            
            
        }

        public ICommand DoPlayCommand
        {

            get
            {
                return new MvxCommand(() =>
                {
                    DoPlay();

                }

                    );
            }
        }

        public void DoPlay()
        {
            if (!IsPlayMusic)
                    {
                        //NewPlaySong = true;
                        //IsPlayMusic = false;
                        MyResolve(Item);
                        IsPlayMusic = true;
                    }
                    else
                    {
                        MyResolve(Item);
                        IsPlayMusic = false;
                        NewPlaySong = false;
                    }
        }
        public ICommand DoPrevCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    int index = _dataMusics.FindIndex(bk => bk.Id == Item.Id);


                    NewPlaySong = true;
                    IsPlayMusic = false;
                    if (index < DataMusics.Count && index > 0)
                    {
                        Item = DataMusics[index - 1];
                    }
                    MyResolve(Item);
                    IsPlayMusic = true;
                }
                    );
            }
        }
        public ICommand DoNextCommand
        {

            get
            {

                return new MvxCommand(() =>
                {
                    
                    int index = _dataMusics.FindIndex(bk => bk.Id == Item.Id);
                    
                    
                    NewPlaySong = true;
                    IsPlayMusic = false;
                    if (index < DataMusics.Count - 1 && index >=0 )
                    {

                        Item = DataMusics[index + 1];

                    } 
                    MyResolve(Item);
                    IsPlayMusic = true;
                });
            }

            
        }

        public ICommand PlayListsCommand
            
        {
            get { return new MvxCommand(() =>
            {
                ShowViewModel<PLsViewModel>();
                Close(this);
            }); }
            
        }

        
    }
}
