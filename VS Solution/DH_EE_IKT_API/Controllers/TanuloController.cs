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

        [HttpPost]
        public async Task<IActionResult> AddTanulo([FromBody] Tanulo tanulo) 
        {
            string newHash = JelszoHash(tanulo.P_Hash, tanulo.P_Salt);
            tanulo.P_Hash = newHash;
            _context.Tanulok.Add(tanulo);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTanulo(int id)
        {
            var tanulo = _context.Tanulok.Where(x => x.ID == id).First();
            /*var jegyek = _context.Jegyek.Where(x => x.ID == id);
            foreach (var jegy in jegyek)
            {
                _context.Jegyek.Remove(jegy);
            }*/
            _context.Tanulok.Remove(tanulo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private static string JelszoHash(string passHash, string salt)
        {
            byte[] passBytes = Encoding.UTF8.GetBytes(passHash);
            string[] strArray = salt.Split('-');
            byte[] _saltArray = new byte[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                _saltArray[i] = Convert.ToByte(strArray[i], 16);
            }
            Rfc2898DeriveBytes rfc2898DeriveBytes = new(passBytes, _saltArray, 25000, HashAlgorithmName.SHA256);
            byte[] hashByte = rfc2898DeriveBytes.GetBytes(32);
            string newPassHash = BitConverter.ToString(hashByte);
            return newPassHash;
        }
    }
}
