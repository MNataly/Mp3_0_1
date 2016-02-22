using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;

namespace Mp3.Core.Models.Messanger
{
    public class MyMessageModel : MvxMessage
    {
        public MyMessageModel(object sender, int filePath, bool isPlayMusic, bool newPlaySong)
            : base(sender)
        {
           
            FilePath = filePath;
            IsPlayMusic = isPlayMusic;
            NewPlaySong = newPlaySong;
        }
        
        public int FilePath { get; private set; }
        public bool IsPlayMusic { get; private set; }
        public bool NewPlaySong { get; private set; }
    }
}
