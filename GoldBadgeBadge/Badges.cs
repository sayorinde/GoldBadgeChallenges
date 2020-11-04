using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeBadge
{
    public class Badges
    {
        public int BadgeID { get; set; }

        public List<string> Doors { get; set; }

        public Badges() { }
        public Badges(int id)
        {
            BadgeID = id;
        }
        public Badges(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
    }
}
