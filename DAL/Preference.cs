using System;

namespace DAL
{
    public class Preference : IComparable<Preference>
    {
        public string UserID { get; set; }
        public int Performer { get; set; }
        public int Title { get; set; }

        public int CompareTo(Preference otherPreference)
        {
            return this.UserID.CompareTo(otherPreference.UserID);
        }
    }
}
