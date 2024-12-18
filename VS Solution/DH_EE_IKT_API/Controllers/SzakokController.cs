using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzakokController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SzakokController(AppDbContext context) { _context = context; }

        [HttpGet]
        public IEnumerable<Szak> GetSzakok()
        {
            return _context.Szakok;
        }

        [HttpPost]
        public async Task<IActionResult> AddSzak([FromBody] Szak szak)
        {
            _context.Szakok.Add(szak);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
