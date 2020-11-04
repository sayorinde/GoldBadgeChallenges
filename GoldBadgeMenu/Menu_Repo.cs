using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeMenu
{
    public class Menu_Repo
    {
        //This method adds to the menu
        private List<Menu> _menu = new List<Menu>();
        public bool AddToMenu(Menu item)
        {
            int startingCount = _menu.Count;

            _menu.Add(item);
            bool wasAdded = _menu.Count > startingCount;
            return wasAdded;
        }
        // Method to display all menu items
        public List<Menu> GetFullMenu()
        {
            return _menu;
        }
        // Method for getting menu items via meal number
        public Menu GetMenuItem(int mealNum)
        {
            foreach (Menu menu in _menu)
            {
                if (menu.MealNum == mealNum)
                {
                    return menu;
                }
            }
            return null;
        }
        // Method for deleting menu items
        public bool DeleteMenuItem(Menu item)
        {
            bool deleteItem = _menu.Remove(item);
            return deleteItem;
        }
    }
}
