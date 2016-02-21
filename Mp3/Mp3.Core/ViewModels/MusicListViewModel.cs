using System.Collections.Generic;
using System.Windows.Input;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using SQLite.Net;

namespace Mp3.Core.ViewModels
{
    public class MusicListViewModel : MvxViewModel, IMusicListViewModel
    {
        private List<DataMusic> _listSongs;
       
        public MusicListViewModel()
        {
           
            DoList();
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

        public ICommand MusicListCommand
        {
            get { return new MvxCommand(() => ShowViewModel<MusicListViewModel>()); }
        }

        IPlayMusicService myVar = Mvx.Resolve<IPlayMusicService>();

        
        public void MyResolve(DataMusic dataMusic)
        {
            //var muzService = Mvx.Resolve<IPlayMusicService>();
            //string str = muzService.PlayTrack();

            var messanger = Mvx.Resolve<IMvxMessenger>();
            var message = new MyMessageModel(this, dataMusic.Id);
            messanger.Publish(message);
        }


        private void DoList()
        {
            var listServise = Mvx.Resolve<ISoungsManagerService>();
            
            DataMusics = listServise.getPlayList;
            
        }

       

        
        public List<DataMusic> GetListMusic()
        {
            return DataMusics;
        }

        public ICommand TapItemMusicCommand
        {
            //get
            //{
            //    return new MvxCommand<DataMusic>(item =>MyResolve(item));
            //}
            get
            {
                return
                    new MvxCommand<DataMusic>(
                        (item) =>
                        {
                            ShowViewModel<PlayerViewModel>(new PlayerViewModel.PlayerData()
                            {
                                Id = item.Id,
                                Name = item.Name,
                                FilePath = item.FilePath
                            });
                        });
                
            }
        }
    }
}
