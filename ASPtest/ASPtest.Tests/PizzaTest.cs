using ASPtest.Pages.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPtest.Tests
{
    [TestClass]
    public class PizzaTest
    {

        [TestMethod]
        public void PizzaModel_GetsPizzas()
        {
            //Arrange
            var pizzasdata = new FakePizzas();
            var pizzaModel = new PizzaModel(pizzasdata);

            //Act
            pizzaModel.OnGet();

            //Assert
            Assert.IsNotNull(pizzaModel.Pizzas);
            Assert.AreEqual(3, pizzaModel.Pizzas.Count);
        }

        [TestMethod]
        public void PizzaModel_GetOnePizza()
        {
            //Arrange
            var pizzasdata = new FakePizzas();
            var pizzaModel = new PizzaModel(pizzasdata);

            //Act
            pizzaModel.OnGet();

            //Assert
            Assert.IsNotNull(pizzaModel.Pizzas);
            Assert.AreEqual("one", pizzaModel.Pizzas.First());
        }



        [TestMethod]
        public void PizzaModel_GetOnePizzaByName()
        {
            //Arrange
            var pizzasdata = new FakePizzas();
            var pizzaModel = new PizzaModel(pizzasdata);

            //Act
            pizzaModel.OnGet();
            var singlepizza = pizzasdata.GetPizzassByName("one");

            //Assert
            Assert.IsNotNull(pizzaModel.Pizzas);
            Assert.AreEqual(true, pizzaModel.Pizzas.Contains(singlepizza));
        }

    }
}
