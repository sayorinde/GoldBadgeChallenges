using System;
using System.Collections.Generic;
using GoldBadgeMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadgeMenu_Test
{
    [TestClass]
    public class Menu_Test
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBool()
        {
            //Arrange
            Menu item = new Menu();
            Menu_Repo menu = new Menu_Repo();
            //Act
            bool addResult = menu.AddToMenu(item);
            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetFullMenu_ShouldReturnCorrectCollection()
        {
            //Arrange
            Menu item = new Menu();
            Menu_Repo menu = new Menu_Repo();
            menu.AddToMenu(item);
            //Act
            List<Menu> menuItems = menu.GetFullMenu();
            bool menuHasItems = menuItems.Contains(item);
            //Assert
            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void GetMenuItem_ShouldReturnCorrectMenuItem()
        {
            //Arrange
            Menu_Repo menu = new Menu_Repo();
            Menu item = new Menu(1,
                "BigWhopper",
                "Double-decker meaty deliciousness",
                "2 quarter pound patties. Double decker bun. Extra Special Secret Sauce of Secretty Secrets.",
                6.99);
            menu.AddToMenu(item);
            int mealNum = 1;
            //Act
            Menu searchResult = menu.GetMenuItem(mealNum);
            //Assert
            Assert.AreEqual(searchResult.MealNum, mealNum);

        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange
            Menu_Repo menu = new Menu_Repo();
            Menu item = new Menu(1,
                "BigWhopper",
                "Double-decker meaty deliciousness",
                "2 quarter pound patties. Double decker bun. Extra Special Secret Sauce of Secretty Secrets.",
                6.99);
            menu.AddToMenu(item);
            int mealNum = 1;
            //Act
            Menu oldItem = menu.GetMenuItem(mealNum);
            bool removeResult = menu.DeleteMenuItem(oldItem);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
