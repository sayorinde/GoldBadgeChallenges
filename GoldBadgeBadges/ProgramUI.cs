using GoldBadgeBadge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeBadges_UI
{
    class ProgramUI
    {
        private Badges_Repo _repo = new Badges_Repo();

        public void Run()
        {
            SeedBadges();
            Menu();
        }


        public void SeedBadges()
        {
            Badges badge1 = new Badges(12345, new List<string> { "A7" });
            _repo.CreateBadge(badge1);
            Badges badge2 = new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _repo.CreateBadge(badge2);
            Badges badge3 = new Badges(32345, new List<string> { "A4", "A5" });
            _repo.CreateBadge(badge3);

        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("1. Add a Badge");
                Console.WriteLine("2. Edit a Badge");
                Console.WriteLine("3. View all Badges");
                Console.WriteLine("4. Exit");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void CreateBadge()
        {

            Console.Clear();
            Console.WriteLine("Enter a badge number");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            if (_repo.GetSingleBadge(badgeNum) != null)
            {
                Console.WriteLine("ERROR: Badge already exist");
            }
            else
            {

                Badges Badge = new Badges(badgeNum);
                bool repeat = true;
                List<string> doors = new List<string>();
                while (repeat)
                {
                    Console.WriteLine("Enter the door/s that the new badge needs to access ");
                    doors.Add(Console.ReadLine());
                    Console.WriteLine("Continue adding doors? Yes/No)?");
                    string moreDoors = Console.ReadLine();
                    if (moreDoors.ToLower() == "n")
                    {
                        repeat = false;
                    }
                }
                Badge.Doors = doors;

            }
            Console.ReadKey();
        }

        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the badge number you want to change");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badges badgeToUpdate = _repo.GetSingleBadge(badgeNum);
            List<string> doors = new List<string>();
            if (badgeToUpdate != null)
            {
                doors = badgeToUpdate.Doors;
                bool repeat = true;
                while (repeat)
                {

                    Console.Clear();
                    string doorsResult = string.Join(",", badgeToUpdate.Doors);

                    Console.WriteLine("What would you like to do to this badge \n" +
                                      "1. Remove a door \n " +
                                      "2. Add a door \n" +
                                      "3. Exit ");
                    string menuSelect = Console.ReadLine();
                    switch (menuSelect)
                    {
                        case "1":
                            Console.WriteLine("Enter a door to delete?");
                            string doorToRemove = Console.ReadLine();
                            doors.Remove(doorToRemove);
                            badgeToUpdate.Doors = doors;
                            Console.WriteLine("Door Removed");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Which door/s are you adding?");
                            string doorToAdd = Console.ReadLine();
                            doors.Add(doorToAdd);
                            badgeToUpdate.Doors = doors;
                            Console.WriteLine("Door" + doors + "Added");
                            Console.ReadKey();
                            break;
                        case "3":
                            repeat = false;
                            break;
                    }

                }


            }

            Console.ReadKey();

        }
        public void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _repo.ShowAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                string doorsResult = string.Join("   ", badge.Value);
                Console.WriteLine($"{badge.Key}      {doorsResult}");

            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
