using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;


namespace Mp3.Droid.Views
{
    [Activity(Label = "New Music List")]
    public class MusicListView : MvxActivity
    {
        //Button startPlayback = null;
        //private MediaPlayer player = new MediaPlayer();
        //private string filePath = "/storage/emulated/0/Music/Lindsey Stirling - Shadows.mp3";

        //private MvxSubscriptionToken _token;


        //List<Dictionary<string, string>> songsList = new List<Dictionary<string, string>>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MusicListView);

            //var messenger = Mvx.Resolve<IMvxMessenger>();
            //_token = messenger.Subscribe<MyMessageModel>(Play);

            //DroidSongsManagerService plm = new DroidSongsManagerService();
            //songsList = plm.getPlayList;
        }

        //private void Play(MyMessageModel mess)
        //{
        //    PlayTrack(mess.FilePath);
        //}

        //public void PlayTrack(string filePath)
        //{
        //    if (player == null)
        //    {
        //        player = new MediaPlayer();
        //    }
        //    else
        //    {
        //        player.Reset();
        //        player.SetDataSource(filePath);
        //        player.Prepare();
        //        player.Start();
        //    }
        //}
    }
}




