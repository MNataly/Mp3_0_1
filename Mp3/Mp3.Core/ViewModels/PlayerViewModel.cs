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
        

        public void GetAllMusic()
        {
            
        }
        public class PlayerData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string FilePath { get; set; }
        }

        public void Init(DataMusic dm)
        {
            _item = dm;
            
            //var listServise = Mvx.Resolve<IMusicListViewModel>();

            //_dataMusics = listServise.GetListMusic();
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
            var message = new MyMessageModel(this, dataMusic.FilePath);
            messanger.Publish(message);
        }

        public ICommand DoPlayCommand
        {
           
            get { return new MvxCommand(() => MyResolve(Item)); }
        }
    }
}
