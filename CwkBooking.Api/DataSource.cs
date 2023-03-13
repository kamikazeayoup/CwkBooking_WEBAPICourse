using CwkBooking.Domain.Models;
using System.Collections.Generic;

namespace CwkBooking.Api
{
    public class DataSource
    {
        public DataSource() {
            Hotels = GetHotels();
        }
        public List<Hotel> Hotels { get; set; }

        private List<Hotel> GetHotels()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    HotelId= 1,
                    Name = "Concorde" ,
                    Stars = 5,
                    City = "Sharm",
                    Country = "Egypt",
                    Description = "this is awesome!"
                },
                new Hotel
                {
                    HotelId= 2,
                    Name = "Hilton" ,
                    Stars = 5,
                    City = "Cairo",
                    Country = "Egypt",
                    Description = "this is awesome!"
                }

            };

        }

    }
}
