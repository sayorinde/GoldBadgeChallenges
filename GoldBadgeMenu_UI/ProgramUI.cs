using GoldBadgeMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeMenu_UI
{
    public class ProgramUI
    {
        Menu_Repo _menu = new Menu_Repo();

        public void Run()
        {
            CreateItemMenu();
            MainMenu();
        }

        public void CreateItemMenu()
        {

            Menu num1 = new Menu(1,
                "BigWhopper",
                "Double-decker meaty deliciousness",
                "2 quarter pound patties. Double decker bun. Extra Special Secret Sauce of Secretty Secrets.",
                6.99);
            _menu.AddToMenu(num1);

            Menu num2 = new Menu(2,
                "Medium Meatzilla Pizza",
                "An unholy combination of several meats guarenteed to give you the meat sweats or your money back",
                "Meat. More meat. Even more meat. A healthy dose of extra meat. All on a meat crust topped with BBQ sauce and a meat flake seasoning",
                14.99);
            _menu.AddToMenu(num2);
        }

        public void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Main Menu");

                Console.WriteLine("Select the number of your desired task: \n" +
                    "1. View menu items \n" +
                    "2. Add new menu items \n" +
                    "3. Delete menu items \n" +
                    "4. Exit \n");

                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        AddNewItem();
                        break;
                    case "3":
                        DeleteExistingItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("CURRENT MENU");
            List<Menu> menuItems = _menu.GetFullMenu();

            foreach (Menu item in menuItems)
            {
                Console.WriteLine("Meal #:            " + item.MealNum);
                Console.WriteLine("Meal Name:         " + item.Meal);
                Console.WriteLine("Meal Description:  " + item.Description);
                Console.WriteLine("Meal Ingredients:  " + item.Ingredients);
                Console.WriteLine("Meal Price:        $" + item.Price);
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        public void AddNewItem()
        {
            Menu newItem = new Menu();
            bool repeat = true;

            while (repeat)
            {

                Console.Clear();
                Console.WriteLine("Please enter a meal Number");
                newItem.MealNum = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter a meal Name");
                newItem.Meal = Console.ReadLine();

                Console.WriteLine("Please Meal Description");
                newItem.Description = Console.ReadLine();

                Console.WriteLine("Please enter meal ingredients");
                newItem.Ingredients = Console.ReadLine();

                Console.WriteLine("Pelase enter meal price");
                newItem.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Meal Number: {newItem.MealNum}");
                Console.WriteLine($"Meal Name: {newItem.Meal}");
                Console.WriteLine($"Meal Description: {newItem.Description}");
                Console.WriteLine($"Meal Ingredients:   {newItem.Ingredients}");
                Console.WriteLine($"Meal Price:$  {newItem.Price}");
                Console.WriteLine("Does the new menu item look good?");
                string looksGood = Console.ReadLine();
                if (looksGood.ToLower() == "y")
                {
                    _menu.AddToMenu(newItem);
                    Console.WriteLine("Menu item addition success");
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Try again");
                }

            }

            Console.ReadKey();

        }
        public void DeleteExistingItem()
        {
            Menu oldItem = new Menu();
            Console.Clear();
            Console.WriteLine("Enter the meal number of the item you want to remove");

            int mealNum = Convert.ToInt32(Console.ReadLine());
            oldItem = _menu.GetMenuItem(mealNum);

            Console.WriteLine($"Meal Number: {oldItem.MealNum}");
            Console.WriteLine($"Meal Name: {oldItem.Meal}");
            Console.WriteLine($"Meal Description: {oldItem.Description}");
            Console.WriteLine($"Meal Ingredients:   {oldItem.Ingredients}");
            Console.WriteLine($"Meal Price:$  {oldItem.Price}");

            _menu.DeleteMenuItem(oldItem);
        }

    }
}