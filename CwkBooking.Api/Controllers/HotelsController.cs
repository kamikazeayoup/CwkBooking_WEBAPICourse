using CwkBooking.Dal;
using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace CwkBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HotelsController : Controller
    {
        private readonly ILogger<HotelsController> _logger;
        private readonly HttpContext _http;
        private readonly DataContext _ctx;
        public HotelsController(ILogger<HotelsController> logger, IHttpContextAccessor httpContextAccessor,
            DataContext ctx)
        {
            _logger = logger;
            _http = httpContextAccessor.HttpContext;
            _ctx = ctx;
        }
        [HttpGet]
        public async Task <IActionResult> GetAllHotels()
        {
            var hotels = await _ctx.Hotels.ToListAsync();
            return Ok(hotels);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHotelsById(int id) {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h=> h.HotelId== id);
            return Ok(hotel);

        }


        [HttpPost]
        public async Task <IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            _ctx.Hotels.Add(hotel);
             await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHotelsById), new { id = hotel.HotelId }, hotel);
        }

        [Route("{id}")]
        [HttpPut]

        public async Task<IActionResult> UpdateHotel([FromBody] Hotel Updated , int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h=> h.HotelId == id);
            hotel.Stars = Updated.Stars;
            hotel.Description= Updated.Description;
            hotel.Name= Updated.Name;
            _ctx.Hotels.Update(hotel);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]

        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h=>h.HotelId == id);
            _ctx.Hotels.Remove(hotel);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }


        
            
        
    }
    
}
