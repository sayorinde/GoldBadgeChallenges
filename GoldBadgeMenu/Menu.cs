using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeMenu
{
    public class Menu
    { //Example setup
      //Blueberry/_Repo (Class Library) 
      //blueberry.ui (Console App)  
      //blueberrytests (Unit test)

        public int MealNum { get; set; }
        public string Meal { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public Menu() { }
        public Menu(int mealNum, string meal, string description, string ingredients, double price)
        {
            MealNum = mealNum;
            Meal = meal;
            Description = description;
            Ingredients = ingredients;
            Price = price;


        }
    }
}
