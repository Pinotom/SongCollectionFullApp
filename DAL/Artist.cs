using System;

namespace DAL
{
    public class Artist : IComparable<Artist>
    {
        public int ArtistID { get; set; }
        public string Performer { get; set; }

        public int CompareTo(Artist otherArtist)
        {
            return this.Performer.CompareTo(otherArtist.Performer);
        }
    }
}
