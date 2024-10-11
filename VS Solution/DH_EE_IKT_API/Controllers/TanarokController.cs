using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
