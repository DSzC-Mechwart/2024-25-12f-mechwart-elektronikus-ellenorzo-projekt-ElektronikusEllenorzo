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
    }
}
