using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsztalyController : ControllerBase
    {
        public AppDbContext _context;
        public OsztalyController(AppDbContext context) { _context = context; }

        [HttpGet]
        public IEnumerable<Osztaly> Osztalyok()
        {
            return _context.Osztalyok;
        }
    }
}
