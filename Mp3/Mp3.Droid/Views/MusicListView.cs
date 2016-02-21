using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
using Android.OS;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Messenger;


namespace Mp3.Droid.Views
{
    [Activity(Label = "New Music List")]
    public class MusicListView : MvxActivity
    {
        //Button startPlayback = null;
        private MediaPlayer player = new MediaPlayer();
        //private string filePath = "/storage/emulated/0/Music/Lindsey Stirling - Shadows.mp3";

        private MvxSubscriptionToken _token;
        private List<DataMusic> _listSongs;

        private int IdMusic;

        
        //List<Dictionary<string, string>> songsList = new List<Dictionary<string, string>>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MusicListView);

            var listServise = Mvx.Resolve<ISoungsManagerService>();
            _listSongs = new List<DataMusic>();
            _listSongs = listServise.getPlayList;

            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);
           
            //DroidSongsManagerService plm = new DroidSongsManagerService();
            //songsList = plm.getPlayList;
        }

        private void Play(MyMessageModel mess)
        {
            PlayTrack(mess.FilePath);
        }

        public void PlayTrack(int _id)
        {
            IdMusic = _id;
            //if (!player.IsPlaying)
            {
                if (player == null)
                {
                    player = new MediaPlayer();
                }
                else
                {
                    
                    

                    player.Reset();
                    player.SetDataSource(_listSongs[_id].FilePath);
                    player.Prepare();
                    player.Start();


                    player.Completion += PlayerOnCompletion;
                }
            }
            // else
            //{
            //    if ((player != null))
            //    {
            //        if (player.IsPlaying)
            //        {
            //            player.Stop();
            //        }
            //        //player.Release();
            //        //player = null;
            //    }
            //}
        }

        private void PlayerOnCompletion(object sender, EventArgs eventArgs)
        {
            IdMusic++;
            if (IdMusic >= _listSongs.Count)
            {
                IdMusic = 0;

            }
            PlayTrack(IdMusic);
        }
    }
}




