using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TantargyakController : ControllerBase
    {
        public AppDbContext _context;
        public TantargyakController(AppDbContext context) { _context = context; }

        [HttpGet]
        public IEnumerable<Tantargy> GetTantargyak()
        {
            return _context.Tantargyak;
        }

        [HttpPost]
        public async Task<IActionResult> AddTantargy([FromBody] Tantargy tantargy)
        {
            _context.Tantargyak.Add(tantargy);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
