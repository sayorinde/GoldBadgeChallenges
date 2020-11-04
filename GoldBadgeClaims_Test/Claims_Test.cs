using System;
using System.Collections.Generic;
using GoldBadgeClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadgeClaims_Test
{
    public class UnitTest1
    {
        [TestMethod]
        public void ShowAllClaims_ShouldReturnAllClaims()
        {
            //Arrange
            Claims_Repo claims = new Claims_Repo();
            Claims claim3 = new Claims(3, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1),
                 ClaimType.Theft, "Stolen pancake", 400.00);
            //Act
            claims.AddAClaim(claim3);

            Queue<Claims> queue = claims.ShowAllClaims();
            bool containsClaim = queue.Contains(claim3);
          
            //Assert
            Assert.IsTrue(containsClaim);
        }

        [TestMethod]
        public void PullNextClaim_ShouldDequeueClaim()
        {
            //Arrange
            Claims_Repo claims = new Claims_Repo();
            Claims claim1 = new Claims(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465.", 400.00);
            Claims claim2 = new Claims(2, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12),
                ClaimType.Home, "House fire in kitchen.", 400.00);
            Claims claim3 = new Claims(3, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1),
                ClaimType.Theft, "Stolen pancakes.", 400.00);
            //Act
            claims.AddAClaim(claim1);
            claims.AddAClaim(claim2);
            claims.AddAClaim(claim3);
            Queue<Claims> queue = claims.ShowAllClaims();
            claims.PullNextClaim();

            //Assert
            Assert.IsFalse(queue.Contains(claim1));


        }

        [TestMethod]
        public void AddAClaim_ShouldCreateClaim()
        {
            //Arrange
            Claims_Repo claims = new Claims_Repo();

            Claims claim1 = new Claims(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465.", 400.00);
            //Act
            claims.AddAClaim(claim1);
            Queue<Claims> queue1 = claims.ShowAllClaims();

            //Assert
            Assert.IsTrue(queue1.Contains(claim1));
        }
    }
}
