using System;
using System.Collections.Generic;
using System.Windows.Input;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Mp3.Core.ViewModels
{
    public class PlayerViewModel
        : MvxViewModel
    {
        
        //private readonly IDataService _dataService;

        private bool IsPlayMusic = false;
        private bool NewPlaySong = true;
        //public string _duration;
        //public string Duration
        //{
        //    get { return _duration; }
        //    set
        //    {
        //        _duration = value;
        //        RaisePropertyChanged(() => Duration);
        //    }
        //}

        public void Init(DataMusic dm)
        {
            _item = dm;
            
            var listServise = Mvx.Resolve<IMusicListViewModel>();

            _dataMusics = listServise.GetListMusic();
            var _getDuration = Mvx.Resolve<IGetMediaInfo>();
            _item.Duration = _getDuration.GetDuration(_item.FilePath);

        }

        private DataMusic _item;
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

        public DataMusic Item
        {
            get { return _item; }
            set
            {
                _item = value;
                RaisePropertyChanged(() => Item);
            }
        }

        public void MyResolve(DataMusic dataMusic)
        {
            //var muzService = Mvx.Resolve<IPlayMusicService>();
            //string str = muzService.PlayTrack();

            var messanger = Mvx.Resolve<IMvxMessenger>();
            var message = new MyMessageModel(this, dataMusic.Id, IsPlayMusic, NewPlaySong);
            messanger.Publish(message);
            
            
        }

        


        public ICommand DoPlayCommand
        {

            get
            {
                return new MvxCommand(() =>
                {
                    if (!IsPlayMusic)
                    {
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

                    );
            }
        }

        public ICommand DoPrevCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    DataMusic prevItem = new DataMusic();
                    NewPlaySong = true;
                    IsPlayMusic = false;
                    if (Item.Id > 0)
                    {
                        prevItem = DataMusics[Item.Id - 1];
                        Item = prevItem;
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
                    DataMusic nextItem = new DataMusic();
                    NewPlaySong = true;
                    IsPlayMusic = false;
                    if (Item.Id < DataMusics.Count)
                    {
                        nextItem = DataMusics[Item.Id + 1];
                        Item = nextItem;

                    } 
                    MyResolve(Item);
                    IsPlayMusic = true;
                });
            }
        }
    }
}
