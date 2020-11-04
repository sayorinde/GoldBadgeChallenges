using GoldBadgeClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeClaims_UI
{
    public class ProgramUI
    {
        private Claims_Repo _repo = new Claims_Repo();

        public void Run()
        {
            SeedClaims();
            Menu();
        }

        public void SeedClaims()
        {
            Claims claim1 = new Claims(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465", 400.00);
            _repo.AddAClaim(claim1);

            Claims claim2 = new Claims(2, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12),
                ClaimType.Home, "House fire in kitchen", 400.00);
            _repo.AddAClaim(claim2);

            Claims claim3 = new Claims(3, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1),
                ClaimType.Theft, "Stolen pancakeS!!!", 400.00);
            _repo.AddAClaim(claim3);

        }

        public void Menu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.WriteLine("Choose an option: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //show all claims
                        Console.Clear();
                        ShowAllClaims();
                        break;
                    case "2":
                        //pull next claim
                        Console.Clear();
                        PullNextClaim();
                        break;
                    case "3":
                        //enter a new claim
                        Console.Clear();
                        CreateNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Select a valid option");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }


        }

        public void ShowAllClaims()
        {
            Queue<Claims> claims = _repo.ShowAllClaims();

            foreach (Claims claim in claims)
            {
                DisplayClaimItem(claim);
            }
        }

        public void PullNextClaim()
        {
            Queue<Claims> claims = _repo.ShowAllClaims();

            Console.WriteLine("Here is the next claim");
            Claims claim = claims.Peek();

            DisplayClaimItem(claim);

            Console.WriteLine("Do you want to deal with this claim now(y/n)? y");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                bool wasRemoved = _repo.PullNextClaim();
                if (wasRemoved)
                {
                    Console.WriteLine("Mission Accomplished");
                }
                else
                {
                    Console.WriteLine("ERROR. Please try again.");
                }
            }

        }

        public void CreateNewClaim()
        {
            Console.WriteLine("Enter the claim ID: ");
            int claimId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Pick a claim type: ");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Home");
            Console.WriteLine("3. Theft");

            string claimInt = "";

            bool repeat = true;
            while (repeat)
            {
                claimInt = Console.ReadLine();
                int i;

                bool res = Int32.TryParse(claimInt, out i);

                if (res && Int32.Parse(claimInt) <= 3)
                {
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("An error has occured. Please try again.");
                }
            }

            ClaimType claimType = (ClaimType)Int32.Parse(claimInt);

            Console.WriteLine("Enter a claim description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter amount of damage : ");
            double claimAmount = Double.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of accident (mm/dd/yyyy): ");
            DateTime accidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date of claim (mm/dd/yyyy): ");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());

            Claims claim = new Claims(claimId, accidentDate, claimDate, claimType, description, claimAmount);

            _repo.AddAClaim(claim);

            Console.WriteLine("Claim added successfully");


        }

        public void DisplayClaimItem(Claims claim)
        {
            Console.WriteLine("ID" + "     " + "ClaimType" + "        " + "Description" + "        " + "ClaimAmount" + "      " +
               "Indident Date" + ("      ") +
           "Claim Date" + "     " + "Is Valid?");

            Console.WriteLine(claim.ClaimId + "        " + claim.ClaimType + "        " + claim.Description + "        " + claim.ClaimAmount + "             "+
                claim.IncidentDate.ToShortDateString() + ("      ") +
            claim.ClaimDate.Date.ToShortDateString() + "     " +claim.IsValid());
        }
    }
}
