using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Widget;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using Mp3.Droid.Service;
using Mp3.Droid.Services;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Mp3.Droid.Views
{
    [Activity(Label = "")]
    public class PlayerView : MvxActivity
    {
        
        //private bool statusplayer = false;
        private List<DataMusic> _listSongs;
       
        private ImageView ImageSong;
        private ImageButton ImageButton;
        private SeekBar SeekBar;

        private MvxSubscriptionToken _token;
        MediaPlayer player;
       
        private int stopPlayer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PlayerView);
             _listSongs = new List<DataMusic>();
            
            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);
            

            ImageSong = FindViewById<ImageView>(Resource.Id.Image);
            ImageButton = FindViewById<ImageButton>(Resource.Id.Play);
            //SeekBar = FindViewById<SeekBar>(Resource.Id.PosSeek);

        }
        

        
        private void Play(MyMessageModel mess)
        {
            DroidPlayMusicService droidPlayMusicService = new DroidPlayMusicService(player);
            //if (mess.NewPlaySong == true) stopPlayer = 0;
            //if (!mess.IsPlayMusic)
            //{
            int currentPos = droidPlayMusicService.GetCurrentPos();
            player = droidPlayMusicService.PlayTrack(mess.FilePath, mess.IsPlayMusic, mess.NewPlaySong, currentPos);


            //}
            //else
            //{
            //    stopPlayer = droidPlayMusicService.Pause();
            //}
            _listSongs = mess.DataMusics;
                MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
                metaRetriever.SetDataSource(_listSongs.Find(bk => bk.Id == mess.FilePath).FilePath);
                byte[] data = metaRetriever.GetEmbeddedPicture();
            
            
                if (data != null)
                {

                    Bitmap bitmap = BitmapFactory.DecodeByteArray(data, 0, data.Length);


                    ImageSong.SetImageBitmap(bitmap);
                    ImageSong.SetAdjustViewBounds(true);
                    ImageSong.LayoutParameters.Width = 650;
                    ImageSong.LayoutParameters.Height = 650;
                    
                }
                else
                {
                    ImageSong.SetImageResource(Resource.Drawable.adele);
                    ImageSong.SetAdjustViewBounds(true);
                    ImageSong.LayoutParameters.Width = 650;
                    ImageSong.LayoutParameters.Height = 650;
                }

            if (mess.IsPlayMusic)
            {
                ImageButton.SetImageResource(Resource.Drawable.BtnPlay);
            }
            if (!mess.IsPlayMusic)
            {
                ImageButton.SetImageResource(Resource.Drawable.BtnPause);
            }
        }

    
    }

    
    
}