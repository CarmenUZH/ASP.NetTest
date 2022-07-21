using ASPtest.Pages.Restaurants;
using Microsoft.Extensions.Configuration;

namespace ASPtest.Tests
{
    [TestClass]
    public class ListModelTest
    {
        [TestMethod]
        public void ListModel_GetsPizzarias()
        {
            //Arrange
            var restaurantdata = new FakeData();
            var listModel = new ListModel( restaurantdata);

            //Act
            listModel.OnGet();

            //Assert
            Assert.IsNotNull(listModel.Restaurants);
            Assert.AreEqual(3, listModel.Restaurants.Count());
        }

        [TestMethod]
        public void ListModel_GetsOnePizzaria()
        {
            //Arrange
            var restaurantdata = new FakeData();
            var listModel = new ListModel(restaurantdata);

            //Act
            listModel.SearchTerm = "ONE";
            listModel.OnGet();

            //Assert
            Assert.IsNotNull(listModel.Restaurants);
            Assert.AreEqual(1, listModel.Restaurants.Count());
            Assert.AreEqual("ONE", listModel.Restaurants.First().Name);
        }
    }
}