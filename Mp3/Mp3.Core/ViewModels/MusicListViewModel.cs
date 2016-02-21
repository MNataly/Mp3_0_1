using System.Collections.Generic;
using System.Windows.Input;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Mp3.Core.ViewModels
{
    public class MusicListViewModel : MvxViewModel, IMusicListViewModel
    {
        private List<Dictionary<string, string>> _listSongs;

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


        private string _playMp3 = "Play";

        public string PlayMp3
        {
            get { return _playMp3; }
            set
            {
                _playMp3 = value;
                RaisePropertyChanged(() => PlayMp3);
            }
        }

        private string _musicList = "Music List";

        public string MusicList
        {
            get { return _musicList; }
            set
            {
                _musicList = value;
                RaisePropertyChanged(() => MusicList);
            }
        }

        public ICommand MusicListCommand
        {
            get { return new MvxCommand(() => ShowViewModel<MusicListViewModel>()); }
        }

        IPlayMusicService myVar = Mvx.Resolve<IPlayMusicService>();

        //public ICommand PlayCommand
        //{
        //    get
        //    {
        //        return new MvxCommand(MyResolve);
        //    }
        //}

        public void MyResolve(DataMusic dataMusic)
        {
            //var muzService = Mvx.Resolve<IPlayMusicService>();
            //string str = muzService.PlayTrack();

            var messanger = Mvx.Resolve<IMvxMessenger>();
            var message = new MyMessageModel(this, dataMusic.FilePath);
            messanger.Publish(message);
        }


        private void DoList()
        {
            var listServise = Mvx.Resolve<ISoungsManagerService>();
            _listSongs = new List<Dictionary<string, string>>();
            _listSongs = listServise.getPlayList;
            MusucListCreate();
        }

        private void MusucListCreate()
        {
            Dictionary<string, string> tDictionary = new Dictionary<string, string>();
            DataMusics = new List<DataMusic>(_listSongs.Count);
            foreach (var m in _listSongs)
            {
                tDictionary = m;
                DataMusic Song = new DataMusic();
                foreach (var t in tDictionary)
                {
                    if (t.Key == "songTitle")
                    {
                        Song.Name = t.Value;
                    }
                    if (t.Key == "songPath")
                    {
                        Song.FilePath = t.Value;
                    }
                }

                DataMusics.Add(Song);
            }
           
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
                //return new MvxCommand<DataMusic>(item =>ShowViewModel<PlayerViewModel>(new PlayerViewModel.Nav(){Id = item.Id,Name = item.Name,FilePath = item.FilePath}));
            }
        }
    }
}
