using System;

namespace DAL
{
    public class SongCollection : IComparable<SongCollection>
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public int Price { get; set; }

        public int CompareTo(SongCollection otherSong)
        {
            return this.Title.CompareTo(otherSong.Title);
        }
    }
}
