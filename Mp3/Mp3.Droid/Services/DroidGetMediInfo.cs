using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mp3.Core.ViewModels;

namespace Mp3.Droid.Services
{
    public class DroidGetMediInfo : IGetMediaInfo
    {
        public string GetDuration(string FilePath)
        {
            MediaMetadataRetriever metaRetriever = new MediaMetadataRetriever();
            metaRetriever.SetDataSource(FilePath);

            string outstr = "";

            string duration = metaRetriever.ExtractMetadata(MetadataKey.Duration);

            int seconds = ((Convert.ToInt32(duration) % 60000) / 1000);
            int minutes = (Convert.ToInt32(duration) / 60000);
            outstr = minutes + ":" + seconds;
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