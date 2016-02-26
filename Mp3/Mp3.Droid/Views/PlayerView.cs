using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
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

        private MvxSubscriptionToken _token;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PlayerView);
             _listSongs = new List<DataMusic>();
            
            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);
            

            ImageSong = FindViewById<ImageView>(Resource.Id.Image);

            

        }
        

        
        private void Play(MyMessageModel mess)
        {

            _listSongs = mess.DataMusics;
                MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
                metaRetriever.SetDataSource(_listSongs.Find(bk => bk.Id == mess.FilePath).FilePath);
                byte[] data = metaRetriever.GetEmbeddedPicture();

                if (data != null)
                {

                    Bitmap bitmap = BitmapFactory.DecodeByteArray(data, 0, data.Length);


                    ImageSong.SetImageBitmap(bitmap);
                    ImageSong.SetAdjustViewBounds(true);
                    ImageSong.LayoutParameters.Width = 550;
                    ImageSong.LayoutParameters.Height = 550;
                    
                }
                else
                {
                    ImageSong.SetImageResource(Resource.Drawable.adele);
                }
            
        
        }

    
    }

    
    
}