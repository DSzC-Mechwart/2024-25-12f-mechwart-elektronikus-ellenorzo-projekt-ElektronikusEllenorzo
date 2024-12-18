using DH_EE_IKT_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DH_EE_IKT_API.Models;
using System.Security.Cryptography;
using System.Text;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanuloController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TanuloController(AppDbContext context) { _context = context;  }

        [HttpGet]
        public IEnumerable<Tanulo> GetTanulok()
        {
            return _context.Tanulok;
        }

        [HttpGet("{osztalyId}")]
        public IEnumerable<Tanulo> GetOsztalyTanulok(string osztalyId)
        {
            return _context.Tanulok.Where( x => x.Osztaly_ID == osztalyId);
        }

        [HttpGet("tanulo/{tanuloId}")]
        public Tanulo? GetTanar(int tanuloId)
        {
            return _context.Tanulok.Where(x => x.ID == tanuloId).FirstOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> AddTanulo([FromBody] Tanulo tanulo) 
        {
            _context.Tanulok.Add(tanulo);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTanulo(int id)
        {
            var tanulo = _context.Tanulok.Where(x => x.ID == id).First();
            _context.Tanulok.Remove(tanulo);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
