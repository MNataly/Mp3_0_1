using System;
using Android.Media;

namespace Mp3.Droid.Services
{
    public class DroidGetMediInfo 
    {
        public string GetDuration(string FilePath)
        {
            MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
            metaRetriever.SetDataSource(FilePath);

            string outstr = "";
            string secondsString = "";
            string duration = metaRetriever.ExtractMetadata(MetadataKey.Duration);

            int seconds = ((Convert.ToInt32(duration) % 60000) / 1000);
            if (seconds < 10)
            {
                secondsString = "0" + seconds;
            }
            else
            {
                secondsString = "" + seconds;
            }
            int minutes = (Convert.ToInt32(duration) / 60000);
            outstr = minutes + ":" + secondsString;
            return outstr;

        }

        public string GetArtist(string FilePath)
        {
            MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
            metaRetriever.SetDataSource(FilePath);
            string outstr = metaRetriever.ExtractMetadata(MetadataKey.Artist);
            return outstr; 
        }

        public string GetName(string FilePath)
        {
            MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
            metaRetriever.SetDataSource(FilePath);
            string outstr = metaRetriever.ExtractMetadata(MetadataKey.Title);
            return outstr;
        }
    }
}