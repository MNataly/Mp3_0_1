using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Mp3.Core.Services
{
    public class DataMusic
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Duration { get; set; }
        public string Artist { get; set; }

        public bool IsChecked { get; set; }
    }
}
