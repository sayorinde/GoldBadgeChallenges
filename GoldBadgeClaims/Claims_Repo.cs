using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeClaims
{
    public class Claims_Repo
    {
        private Queue<Claims> _claims = new Queue<Claims>();

        // Show all claims
        public Queue<Claims> ShowAllClaims()
        {
            return _claims;
        }

        // Pull next claim
        public bool PullNextClaim()
        {
            int startingCount = _claims.Count;

            _claims.Dequeue();

            return startingCount > _claims.Count;
        }

        // Add a claim
        public bool AddAClaim(Claims claim)
        {
            int startingCount = _claims.Count;

            _claims.Enqueue(claim);

            return startingCount < _claims.Count;
        }
    }
}
