using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Text.Json.Serialization;

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
            return _context.Jegyek.Where(x => x.Tanulo_ID == id);
        }

        [HttpGet("osztalyok/{osztaly}")]
        public IEnumerable<Jegy> GetOsztalyJegyek(string osztaly)
        {
            return _context.Jegyek.Where(x => x.Osztaly_ID.ToLower() == osztaly.ToLower());
        }

        [HttpGet("osztalyok/vmi/{osztaly}")]
        public object GetOsztalyJegyek2(string osztaly)
        {
            var osztalyJegyek = _context.Jegyek.Where(x => x.Osztaly_ID.ToLower() == osztaly.ToLower()).ToList();
            var tanulok = _context.Tanulok.Where(x => x.Osztaly_ID.ToLower() == osztaly.ToLower()).ToList();
            var joined = tanulok.GroupJoin(osztalyJegyek, x => x.ID, jegyek => jegyek.Tanulo_ID, (x,jegyek) => new { nev = x.Nev, jegyek = jegyek.GroupBy(x => x.Datum.Month).ToDictionary(x => x.Key, x => x.Select(y => new { y.Jegy_Ertek, y.Tema }).ToList()) }).ToList();
            return joined;
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
