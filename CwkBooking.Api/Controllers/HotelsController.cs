using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CwkBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HotelsController : Controller
    {
        public readonly DataSource _DataSource;
        public HotelsController(DataSource dataSource)
        {
            _DataSource = dataSource;
        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _DataSource.Hotels;
            return Ok(hotels);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetHotelsById(int id) {
            var hotels = _DataSource.Hotels;
            var hotel = hotels.FirstOrDefault(h=> h.HotelId== id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);

        }


        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _DataSource.Hotels;
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelsById), new { id = hotel.HotelId }, hotel);
        }

        [Route("{id}")]
        [HttpPut]

        public IActionResult UpdateHotel([FromBody] Hotel Updated , int id)
        {
            var hotels = _DataSource.Hotels;
            var old = hotels.FirstOrDefault(h => h.HotelId == id);
            if (old == null)
                return NotFound("cannot EDIT , out of boundries id or not found");
            hotels.Remove(old);
            hotels.Add(Updated);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]

        public IActionResult DeleteHotel(int id)
        {
            var hotels = _DataSource.Hotels;
            var ToDelete = hotels.FirstOrDefault(h => h.HotelId == id);
            if (ToDelete == null) 
                return NotFound("cannot Delete , out of boundries id or not found");

            hotels.Remove(ToDelete);
            return NoContent();
        }


        
            
        
    }
    
}
