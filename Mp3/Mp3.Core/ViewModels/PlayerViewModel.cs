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
        
        private IDataService _dataService;

        private bool IsPlayMusic = false;
        private bool NewPlaySong = true;

        public PlayerViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataMusics = _dataService.GetMusics();
        }

        public void Init(DataMusic dm)
        {
            _item = dm;
            
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
            var message = new MyMessageModel(this, dataMusic.Id, IsPlayMusic, NewPlaySong, _dataMusics);
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
                    int index = DataMusics.IndexOf(Item);
                    
                    NewPlaySong = true;
                    IsPlayMusic = false;
                    if (index < DataMusics.Count - 1 && index >= 0)
                    {

                        Item = DataMusics[index + 1];

                    } 
                    MyResolve(Item);
                    IsPlayMusic = true;
                });
            }
        }
    }
}
