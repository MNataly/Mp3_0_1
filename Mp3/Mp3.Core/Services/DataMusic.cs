using SQLite.Net.Attributes;

namespace Mp3.Core.Services
{
    public class DataMusic
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}
