using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanarokController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TanarokController(AppDbContext context) { _context = context; }

        [HttpGet]
        public IEnumerable<Tanar> GetTanarok()
        {
            return _context.Tanarok;
        }

        [HttpGet("{id}")]
        public Tanar? GetTanar(int id)
        {
            return _context.Tanarok.Where(x => x.ID == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> AddTanar([FromBody] Tanar tanar)
        {
            _context.Tanarok.Add(tanar);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
