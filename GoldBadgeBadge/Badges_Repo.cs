using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeBadge
{
    public class Badges_Repo
    {
        private Dictionary<int, List<string>> _repo = new Dictionary<int, List<string>>();
        //Method to create a new badge
        public bool CreateBadge(Badges badge)
        {
            if (_repo.ContainsKey(badge.BadgeID))
            {
                Console.WriteLine("Enter a valid ID");
                return false;
            }
            else
            {
                _repo.Add(badge.BadgeID, badge.Doors);
                Console.WriteLine("Badge created.");
                return false;
            }
        }
        //Method for returning all badges
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _repo;
        }

        //Method to return a badge by ID number
        public Badges GetSingleBadge(int BadgeID)
        {
            if (_repo.ContainsKey(BadgeID))
            {
                Badges badge = new Badges(BadgeID);
                badge.Doors = _repo[BadgeID];
                return badge;
            }
            else
            {
                Console.WriteLine("That badge does not exist. Lets add doors to it.");
                return null;
            }

        }
        //Method to update a badge number

        public bool UpdateBadge(int oldBadgeID, Badges newBadge)
        {
            Badges oldBadge = GetSingleBadge(oldBadgeID);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Doors = newBadge.Doors;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to delete a badge

        public bool DeleteABadge(Badges badge)
        {
            bool deleteBadge = _repo.Remove(badge.BadgeID);
            return deleteBadge;
        }
    }
}
