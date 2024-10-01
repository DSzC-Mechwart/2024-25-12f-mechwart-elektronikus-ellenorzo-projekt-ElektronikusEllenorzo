using DH_EE_IKT_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DH_EE_IKT_API.Models;

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
    }
}
