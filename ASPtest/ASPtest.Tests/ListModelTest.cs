using ASPtest.Pages.Restaurants;
using Microsoft.Extensions.Configuration;

namespace ASPtest.Tests
{
    [TestClass]
    public class ListModelTest
    {
        [TestMethod]
        public void ListModel_GetsPeople()
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
    }
}