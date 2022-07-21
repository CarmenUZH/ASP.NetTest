using ASPtest.Pages.Restaurants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPtest.Tests
{
    [TestClass]
    public class ListModelTest
    {
        private ILogger<ListModel>? _logger;

        [TestMethod]
        public void ListModel_GetsPizzarias()
        {
            //Arrange
            var restaurantdata = new FakeData();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _logger = serviceProvider.GetService<ILogger<ListModel>>();
            var listModel = new ListModel( restaurantdata, _logger);

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
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _logger = serviceProvider.GetService<ILogger<ListModel>>();

            var listModel = new ListModel(restaurantdata, _logger);

            //Act
            listModel.SearchTerm = "ONE";
            listModel.OnGet();

            //Assert
            Assert.IsNotNull(listModel.Restaurants);
            Assert.AreEqual(1, listModel.Restaurants.Count());
            Assert.AreEqual("ONE", listModel.Restaurants.First().Name);
        }


        [TestMethod]
        public void GeneralTest_SeeIfTestsWork() //Even if all else fails, this should run (To make sure the problem is really in the code and not with the testing)
        {
            Assert.AreEqual(1, 1);
        }
    }
}