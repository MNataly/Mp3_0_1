using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Util;
using Android.Widget;
using Java.Lang;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using Mp3.Core.ViewModels;
using Mp3.Droid.Services;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Messenger;


namespace Mp3.Droid.Views
{
	[Activity(Label = "Mp3 List")]
    public class MusicListView : MvxActivity 
    {
        
        //private MediaPlayer player = new MediaPlayer();
        
        //private MvxSubscriptionToken _token;
        
        
        //private ImageView ImageSong;
	    //private SeekBar seekBarPos;

       
       
        //private int Duration;
        
        //private readonly IDataService _dataService;
       
        
        
        
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MusicListView);

            //_listSongs = new List<DataMusic>();
            
            //var messenger = Mvx.Resolve<IMvxMessenger>();
            //_token = messenger.Subscribe<MyMessageModel>(Play);
            //TextView CurentPosSong = FindViewById<TextView>(Resource.Id.PlayPos);
            //seekBarPos = FindViewById<SeekBar>(Resource.Id.PosSeek);

            //ImageSong = FindViewById<ImageView>(Resource.Id.Image);

            

        }
        

        
        //private void Play(MyMessageModel mess)
        //{
        //    _listSongs = mess.DataMusics;
            
        //    //seekBarPos.Max = 200;

            
        //}

        
    }
}




