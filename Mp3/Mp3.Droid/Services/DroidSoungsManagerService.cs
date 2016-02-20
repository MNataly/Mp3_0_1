using System.Collections.Generic;
using Java.IO;
using Mp3.Core.Services;


namespace Mp3.Droid.Service
{
    public class DroidSongsManagerService : ISoungsManagerService
    {
        // SDCard Path
        public readonly string MEDIA_PATH = "/sdcard/";
        private List<Dictionary<string, string>> songsList;

        FileExtensionFilter obj = new FileExtensionFilter();
        // Constructor


        /**
     * Function to read all mp3 files from sdcard
     * 
     * */

        public List<Dictionary<string, string>> getPlayList
        {
            
            get
            {
                songsList = new List<Dictionary<string, string>>();
                File home = new File(MEDIA_PATH);

                File[] listFiles = home.ListFiles();

                scanDirectory(home);

                // return songs list array
                return songsList;
            }
        }


        private void scanDirectory(File directory)
        {
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
            Dictionary<string, string> song = new Dictionary<string, string>();
            song["songTitle"] = file.Name;
            song["songPath"] = file.Path;
            songsList.Add(song);
        }
    }
}