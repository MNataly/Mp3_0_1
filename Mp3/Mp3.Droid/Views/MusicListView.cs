using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Util;
using Android.Widget;
using Java.Lang;
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

        private Handler mHandler = new Handler();
        private SeekBar seekBarPos;
        private DataMusic _dataMusic;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MusicListView);

            _listSongs = new List<DataMusic>();
            
            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);
            CurentPosSong = FindViewById<TextView>(Resource.Id.PlayPos);
            seekBarPos = FindViewById<SeekBar>(Resource.Id.PosSeek);
            CurentPosSong = FindViewById<TextView>(Resource.Id.timeSong);

            //seekBarPos.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            //{
            //    if (e.FromUser)
            //    {
            //        CurentPosSong.Text = string.Format("The value of the SeekBar is {0}", e.Progress);
            //    }
            //};
        }
        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if (fromUser)
            {
                CurentPosSong.Text = string.Format("The you adjusted the value of the SeekBar to {0}", seekBar.Progress);
            }
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            // see http://developer.android.com/reference/android/widget/SeekBar.OnSeekBarChangeListener.html#onStartTrackingTouch(android.widget.SeekBar)
            // for details about this method.
            System.Diagnostics.Debug.WriteLine("Tracking changes.");
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            // see http://developer.android.com/reference/android/widget/SeekBar.OnSeekBarChangeListener.html#onStopTrackingTouch(android.widget.SeekBar)
            // for details about this method
            System.Diagnostics.Debug.WriteLine("Stopped tracking changes.");
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
            DataMusic dataMusic = _listSongs.Find(bk => bk.Id == _id);
            //if (!player.IsPlaying)
            {
                if (player == null)
                {
                    player = new MediaPlayer();
                }
                else
                {
                    
                    if (stopPlayer == 0)
                    {
                        player.Reset();
                        player.SetDataSource(dataMusic.FilePath);
                        player.Prepare();
                    }
                    
                    player.Start();
                    _dataMusic = dataMusic;

                    

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
            
        }
    }
}




