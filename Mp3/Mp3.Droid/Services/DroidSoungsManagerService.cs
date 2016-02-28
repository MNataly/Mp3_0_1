using System.Collections.Generic;
using Java.IO;
using Mp3.Core.Services;
using Mp3.Core.ViewModels;
using Mp3.Droid.Services;
using MvvmCross.Platform;


namespace Mp3.Droid.Service
{
    public class DroidSongsManagerService : ISoungsManagerService
    {
        // SDCard Path
        public readonly string MEDIA_PATH = "/storage/";
        private List<DataMusic> songsList;
        private int Id;
        
        FileExtensionFilter obj = new FileExtensionFilter();
        // Constructor


        /**
     * Function to read all mp3 files from sdcard
     * 
     * */

        public List<DataMusic> getPlayList
        {
            
            get
            {
                songsList = new List<DataMusic>();
                File home = new File(MEDIA_PATH);

                File[] listFiles = home.ListFiles();

                scanDirectory(home);

                // return songs list array
                return songsList;
            }
        }


        private void scanDirectory(File directory)
        {
            Id = 0;
            if (directory != null)
            {
                File[] listFiles = directory.ListFiles();
                if (listFiles != null && listFiles.Length > 0)
                {
                    foreach (File file in listFiles)
                    {
                        if (file.IsDirectory)
                        {
                            scanDirectory(file);
                        }
                        else
                        {
                            if (obj.Accept(file, file.Name) == true)
                            {
                                AddSong(file);
                            }
                        }
                    }
                }
            }
        }

        private void AddSong(File file)
        {
            
            DataMusic song = new DataMusic();
            song.Id = Id;
            
            song.FilePath = file.Path;
            songsList.Add(song);
            DroidGetMediInfo _getDuration = new DroidGetMediInfo();
            song.Duration = _getDuration.GetDuration(song.FilePath);
            song.Artist = _getDuration.GetArtist(song.FilePath);

            song.Name = _getDuration.GetName(song.FilePath);
            if (song.Name == null)
            {
                song.Name = file.Name;
            }
            Id++;
        }
    }
}