using System.Collections.Generic;

namespace Mp3.Core.Services
{
    public interface IPlayMusicService
    {

        void PlayTrack(int _id, bool IsPlayMusic, bool NewPlaySong, int stopPlayer, List<DataMusic> DataMusics );
    }
}
