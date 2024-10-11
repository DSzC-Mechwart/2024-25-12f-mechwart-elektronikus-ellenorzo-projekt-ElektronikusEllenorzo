using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JegyekController : ControllerBase
    {
        public AppDbContext _context;
        public JegyekController(AppDbContext context) { _context = context; }

        [HttpGet]
        public IEnumerable<Jegy> GetJegyek()
        {
            return _context.Jegyek;
        }

        [HttpGet("{id}")]
        public IEnumerable<Jegy> GetJegyek(int id)
        {
            return _context.Jegyek.Where(x => x.Tanulo_ID == id );
        }

        [HttpPost]
        public async Task<IActionResult> AddJegy([FromBody] Jegy jegy)
        {
            _context.Jegyek.Add(jegy);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
