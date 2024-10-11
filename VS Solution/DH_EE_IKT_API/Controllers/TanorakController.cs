using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanorakController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TanorakController(AppDbContext context) { _context = context; }

        [HttpGet]
        public IEnumerable<Tanora> GetTanora()
        {
            return _context.Tanorak;
        }
    }
}
