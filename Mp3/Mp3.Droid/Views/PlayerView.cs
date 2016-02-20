using Android.App;
using Android.Media;
using Android.OS;
using Mp3.Core.Models.Messanger;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Mp3.Droid.Views
{
    [Activity(Label = "View for PlayerViewModel")]
    public class PlayerView : MvxActivity
    {
        private MediaPlayer player = new MediaPlayer();

        private MvxSubscriptionToken _token;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PlayerView);
            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);
        }

        private  void Play(MyMessageModel mess)
        {
             PlayTrack(mess.FilePath);
        }

        public void PlayTrack(string filePath)
        {
            //player = new MediaPlayer();

            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
                player.Reset();
                player.SetDataSource(filePath);
                player.Prepare();
                player.Start();
            }
        }
    }

    
    
}