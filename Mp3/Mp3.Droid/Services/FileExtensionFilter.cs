using System;
using Java.IO;

namespace Mp3.Droid.Service
{
    /**
    * Class to filter files which are having .mp3 extension
    * */

    public class FileExtensionFilter : IFilenameFilter
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr Handle { get; set; }

        public bool Accept(File dir, string filename)
        {
            return (filename.EndsWith(".mp3", StringComparison.Ordinal) ||
                    filename.EndsWith(".MP3", StringComparison.Ordinal));
        }
    }
}