using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrarendekController : ControllerBase
    {
        public AppDbContext _context;
        public OrarendekController(AppDbContext context) { _context = context; }

        [HttpGet("osszes")]
        public IEnumerable<Orarend> GetOrarendek()
        {
            return _context.Orarendek;
        }

        [HttpGet("{id}")]
        public Orarend? GetOrarend(string id)
        {
            try
            {
                return _context.Orarendek.Where(x => x.Osztaly_ID.ToLower() == id.ToLower()).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrarend([FromBody] Orarend orarend)
        {
            _context.Orarendek.Add(orarend);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
