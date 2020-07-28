using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Scott's Pizza", Cuisine=CuisineType.Italian},
                new Restaurant{Id = 2, Name = "Tersiguels", Cuisine=CuisineType.French},
                new Restaurant{Id = 3, Name = "Mango Grove", Cuisine=CuisineType.Indian}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Restaurant restaurant)
        {
            Restaurant r = Get(restaurant.Id);
            r.Cuisine = restaurant.Cuisine;
            r.Name = restaurant.Name;
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }


    }
}
