using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using Java.Lang;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using Mp3.Droid.Service;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;


namespace Mp3.Droid.Views
{
	[Activity(Label = "Mp3 List")]
    public class MusicListView : MvxActivity 
    {
        



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MusicListView);

           
            
        }

        

        
    }
}




