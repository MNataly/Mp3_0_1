using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Util;
using Android.Widget;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using Mp3.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Messenger;


namespace Mp3.Droid.Views
{
    [Activity(Label = "New Music List")]
    public class MusicListView : MvxActivity 
    {
        
        private MediaPlayer player = new MediaPlayer();
        
        private MvxSubscriptionToken _token;
        private List<DataMusic> _listSongs;

        private int IdMusic;
        private int stopPlayer = 0;
        private int Duration;
        private TextView CurentPosSong;
        private readonly IDataService _dataService;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MusicListView);

            //var listServise = Mvx.Resolve<ISoungsManagerService>();

            _listSongs = new List<DataMusic>();

           

            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);
            CurentPosSong = FindViewById<TextView>(Resource.Id.PlayPos);

            //DroidSongsManagerService plm = new DroidSongsManagerService();
            //songsList = plm.getPlayList;
        }

        private void Play(MyMessageModel mess)
        {
            _listSongs = mess.DataMusics;
            if (mess.NewPlaySong == true) stopPlayer = 0;
            if (!mess.IsPlayMusic)
            {
                PlayTrack(mess.FilePath);
            }
            else
            {
                Pause();
            }

            
        }

        public void PlayTrack(int _id)
        {
            IdMusic = _id;
            DataMusic dataMusic = _listSongs.Find(delegate(DataMusic bk)
            {
                return bk.Id == _id;
            });
            //if (!player.IsPlaying)
            {
                if (player == null)
                {
                    player = new MediaPlayer();
                }
                else
                {
                    //GetDuration();


                   // GetDuration();

                    if (stopPlayer == 0)
                    {
                        player.Reset();
                        player.SetDataSource(dataMusic.FilePath);
                        player.Prepare();
                    }
                    
                    player.Start();
                    //CurentPosSong.Text = player.CurrentPosition.ToString();

                    //player.Completion += PlayerOnCompletion;
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

        private void Pause()
        {
             stopPlayer = player.CurrentPosition;
            player.Pause();
            //player.Start();
        }
    }
}




