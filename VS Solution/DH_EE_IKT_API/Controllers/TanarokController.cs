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

        [HttpPost]
        public async Task<IActionResult> AddTanar([FromBody] Tanar tanar)
        {
            string newHash = JelszoHash(tanar.P_Hash, tanar.P_Salt);
            tanar.P_Hash = newHash;
            _context.Tanarok.Add(tanar);
            await _context.SaveChangesAsync();
            return Created();
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
