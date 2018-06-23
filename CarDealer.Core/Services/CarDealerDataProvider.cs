using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Core.Models;

namespace CarDealer.Core.Services
{
    public class CarDealerDataProvider
    {
        private List<Car> _db;

        public CarDealerDataProvider()
        {
            _db = new List<Car>();
            PopulateCarList();
        }

        public void PopulateCarList()
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                _db.Add(new Car
                {
                    CarID = i,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris maximus quam sed dui congue aliquam. Cras tincidunt elit a cursus faucibus. Etiam ut cursus lectus, ac lacinia orci. Sed tincidunt euismod commodo. Nam sit amet tincidunt enim. Donec vitae lacinia dolor, mattis bibendum magna. Morbi luctus volutpat eros, nec faucibus purus tincidunt vel. Etiam gravida pretium eleifend. In non sem eget nulla finibus facilisis. Duis vulputate suscipit dui, vitae tristique turpis. In aliquet tristique ligula a scelerisque. Vestibulum nunc urna, dignissim vel tristique vitae, volutpat quis sem. Cras maximus, metus a dapibus efficitur, erat tortor eleifend lectus, ut hendrerit erat ligula id velit. Nullam lacinia eros sit amet venenatis condimentum. Etiam ut mi tincidunt, dapibus urna eu, ultrices diam. Praesent ac orci ornare, luctus tortor in, auctor erat.",
                    Manufacturer = i % 2 == 0 ? "Volkswagen" : i % 3 == 0 ? "BMW" : "Mercedes",
                    Model = i % 2 == 0 ? "Default" : "Other",
                    Price = random.Next(10000, 90000)                    
                });
            }
        }

        public Car GetCarByID( int id)
        {
            if (_db.Count > id)                 
                return _db[id];

            return null;
        }
        public List<Car> GetAllCars()
        {
            return _db;
        }
    }
}
