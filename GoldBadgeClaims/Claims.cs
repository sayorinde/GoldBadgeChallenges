using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeClaims
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {


        public int ClaimId { get; set; }


        public ClaimType ClaimType { get; set; }


        public string Description { get; set; }


        public double ClaimAmount { get; set; }


        public DateTime IncidentDate { get; set; }

        public DateTime ClaimDate { get; set; }

        public bool IsValid()
        {
            TimeSpan validity = ClaimDate - IncidentDate;
            int days = (int)validity.TotalDays;

            if (days < 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Claims() { }
        public Claims(int id, DateTime incidentDate, DateTime claim, ClaimType claimType, string description, double amount)
        {
            ClaimId = id;
            IncidentDate = incidentDate;
            ClaimDate = claim;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = amount;
        }

    }
}
