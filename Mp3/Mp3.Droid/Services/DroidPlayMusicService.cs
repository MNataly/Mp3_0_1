using System;
using System.Collections.Generic;
using Android.Media;
using Mp3.Core.Services;
using MvvmCross.Plugins.Sqlite;
using MvvmCross.Plugins.Sqlite.Droid;

namespace Mp3.Droid.Service
{
    public class DroidPlayMusicService 
    {
        //MediaPlayer player;
        private int IdMusic;
        private DataMusic dataMusic = new DataMusic();
        private List<DataMusic> _listSongs = new List<DataMusic>();
        //private int stopPlayer;
        private DataMusic _dataMusic;
        private MediaPlayer _mediaPlayer;

        public DroidPlayMusicService(MediaPlayer player)
        {
            _mediaPlayer = player;
        }

        public MediaPlayer PlayTrack(int _id, bool IsPlayMusic, bool NewPlaySong, int stopPlayer)
        {
            IMvxSqliteConnectionFactory connectionFactory = new DroidSqliteConnectionFactory();
            IDataService dataService = new DataService(connectionFactory);
            _listSongs = dataService.GetMusics();
            IdMusic = _id;
            dataMusic = _listSongs.Find(bk => bk.Id == _id);
            //if (!player.IsPlaying)
            if (_mediaPlayer == null)
            {
                _mediaPlayer = new MediaPlayer();
            }
                if (NewPlaySong) stopPlayer = 0;
                if (IsPlayMusic)
                {
                    //player.SetDataSource(dataMusic.FilePath);
                    //player.Prepare();
                    _mediaPlayer.Pause();
                    stopPlayer = _mediaPlayer.CurrentPosition;
                }
                else
                {


                    
                   // else
                    {

                        if (stopPlayer == 0)
                        {
                            _mediaPlayer.Reset();
                            _mediaPlayer.SetDataSource(dataMusic.FilePath);
                            _mediaPlayer.Prepare();
                        }

                        _mediaPlayer.Start();
                        //_dataMusic = dataMusic;



                        //player.Completion += PlayerOnCompletion;
                    }
                }
                return _mediaPlayer;
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


        //private void PlayerOnCompletion(object sender, EventArgs eventArgs)
        //{
        //    IdMusic++;
        //    if (IdMusic >= _listSongs.Count)
        //    {
        //        IdMusic = 0;

        //    }
        //    PlayTrack(IdMusic, false, true);
        //}

        //public int Pause()
        //{
            
        //    player.Pause();
        //    return player.CurrentPosition;
            
        //}
        public int GetCurrentPos()
        {
            if (_mediaPlayer == null)
            {
                return 0;
            }
            else
            {
                return _mediaPlayer.CurrentPosition;
            }
            
        }

    }
}