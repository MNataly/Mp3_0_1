using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Util.Concurrent;
using Mp3.Core.Models.Messanger;
using Mp3.Core.Services;
using Mp3.Droid.Service;
using Mp3.Droid.Services;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;


namespace Mp3.Droid.Views
{
    [Activity(Label = "Player")]
    public class PlayerView : MvxActivity
    {
        private static MediaPlayer player = new MediaPlayer();

        private MvxSubscriptionToken _token;
        private List<DataMusic> _listSongs;
        private DataMusic dataMusic = new DataMusic();
        private ImageView ImageSong;

        private int IdMusic;
        private int stopPlayer;
        private int Duration;

        private readonly IDataService _dataService;



        private static Handler SeekBarHandler;

        private int startTime;

        private DataMusic _dataMusic;



        private ImageButton _imageButton;
        private  SeekBar _seekBar;

        private  TextView _textView;

        private SeekBar _seekVolume;
        private AudioManager audioManager = null;
        int maxVolume = 1;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PlayerView);

            _listSongs = new List<DataMusic>();

            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<MyMessageModel>(Play);


            _imageButton = FindViewById<ImageButton>(Resource.Id.BtnPlay);
            _seekBar = FindViewById<SeekBar>(Resource.Id.PosSeek);
            ImageSong = FindViewById<ImageView>(Resource.Id.Image);
            _textView = FindViewById<TextView>(Resource.Id.PlayPos);
            _seekVolume = FindViewById<SeekBar>(Resource.Id.Vol);
            audioManager = (AudioManager)GetSystemService(Context.AudioService);
            _seekVolume.Max = audioManager.GetStreamMaxVolume(Stream.Music);
            //get current volume
            _seekVolume.Progress = (audioManager.GetStreamVolume(Stream.Music));

           
            //get max volume
            maxVolume = _seekVolume.Max;
            _seekVolume.ProgressChanged += new EventHandler<SeekBar.ProgressChangedEventArgs>(Target2);

        }

        private void Target2(object sender, SeekBar.ProgressChangedEventArgs progressChangedEventArgs)
        {
            audioManager.SetStreamVolume(Stream.Music, progressChangedEventArgs.Progress, 0);
            //Calculate the brightness percentage
            //float perc = (progressChangedEventArgs.Progress / (float)maxVolume) * 100;
            //Set the brightness percentage 
            _seekVolume.Progress = progressChangedEventArgs.Progress;
        }


        private async void Play(MyMessageModel mess)
        {
            _listSongs = mess.DataMusics;
            if (mess.NewPlaySong == true) stopPlayer = 0;
            if (!mess.IsPlayMusic)
            {

                await PlayTrack(mess.FilePath);


            }
            else
            {
                Pause();
            }

            _listSongs = mess.DataMusics;
            DroidGetMediInfo droidGetMediInfo = new DroidGetMediInfo();
            //player.SetDataSource(_listSongs.Find(bk => bk.Id == mess.FilePath).FilePath);
            //player.Prepare();
            //if (mess.NewPlaySong == true) stopPlayer = 0;
            //if (!mess.IsPlayMusic)
            //{

            


            //}
            //else
            //{
            //    stopPlayer = droidPlayMusicService.Pause();
            //}

            MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
            metaRetriever.SetDataSource(_listSongs.Find(bk => bk.Id == mess.FilePath).FilePath);

            int Startime = player.CurrentPosition;
            string DurationSong = metaRetriever.ExtractMetadata(MetadataKey.Duration);
            _seekBar.Max = Convert.ToInt32(DurationSong);
            _seekBar.Progress = Startime;
            string outstr = "";

            string secondsString = "";
            int seconds = ((Convert.ToInt32(Startime) % 60000) / 1000);
            int minutes = (Convert.ToInt32(Startime) / 60000);
            if (seconds < 10)
            {
                secondsString = "0" + seconds;
            }
            else
            {
                secondsString = "" + seconds;
            }
            outstr = minutes + ":" + secondsString;
            _textView.Text = outstr;
            SeekBarHandler = new Handler();
            SeekBarHandler.PostDelayed(UpdateSongTime, 100);

            
            

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
                _imageButton.SetImageResource(Resource.Drawable.BtnPlay);
            }
            if (!mess.IsPlayMusic)
            {
                _imageButton.SetImageResource(Resource.Drawable.BtnPause);
            }
            //_seekBar.SetOnSeekBarChangeListener(new SeekBarListener());


        }
        
        
        private Runnable UpdateSongTime;

        public PlayerView()
        {
            UpdateSongTime = new Runnable(new Action(Target));
        }

        private void Target()
        {
            int startTime = player.CurrentPosition;

            _seekBar.Progress = startTime;
            string outstr = "";

            string secondsString = "";
            int seconds = ((Convert.ToInt32(startTime) % 60000) / 1000);
            if (seconds < 10)
            {
                secondsString = "0" + seconds;
            }
            else
            {
                secondsString = ""+ seconds;
            }
            int minutes = (Convert.ToInt32(startTime) / 60000);
            outstr = minutes + ":" + secondsString;
            _textView.Text = outstr;
            SeekBarHandler.PostDelayed(UpdateSongTime, 100);
            
        }





        public async Task PlayTrack(int _id)
        {
            IdMusic = _id;
            dataMusic = _listSongs.Find(bk => bk.Id == _id);

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

                }
                //player.Completion += PlayerOnCompletion;
                
            }

           



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
    public class SeekBarListener : Java.Lang.Object, SeekBar.IOnSeekBarChangeListener
    {
        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }
    }






}