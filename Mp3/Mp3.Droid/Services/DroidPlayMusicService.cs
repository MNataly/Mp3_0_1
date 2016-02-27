using Android.Media;
using Mp3.Core.Services;

namespace Mp3.Droid.Service
{
    public class DroidPlayMusicService : IPlayMusicService
    {
        MediaPlayer player;
        string filePath = "/storage/emulated/0/Music/Lindsey Stirling - Transcendence.mp3";


        public string PlayTrack()
        {
            
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

            return "label";

        }

        public void PlayTrack(int _id)
        {
            throw new System.NotImplementedException();
        }
    }
}