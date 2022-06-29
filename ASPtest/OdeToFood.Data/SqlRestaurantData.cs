using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq; //Important for SQL query operations

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db; //Dont forget to instantiate
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
           db.Restaurant.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurant.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
             var restaurants = db.Restaurant;
            return restaurants;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurant.Find(id); //Automatically knows how to find it by primary key ID
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurant 
                        where r.Name.StartsWith(name)||string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;

        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurant.Attach(updatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
