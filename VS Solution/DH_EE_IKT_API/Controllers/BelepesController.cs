using DH_EE_IKT_API.Data;
using DH_EE_IKT_API.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls;
using System.Security.Cryptography;
using System.Text;

namespace DH_EE_IKT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BelepesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BelepesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("tipus")]
        public int GetFelhasznaloTipus(int id)
        {
            if (_context.Tanulok.Where(x => x.ID == id).Any()) 
            {
                return 1; // diak
            }
            else if (_context.Tanarok.Where(x => x.ID == id).Any())
            {
                return 2; // tanar
            }
            return -1;
        }

        [HttpGet("salt")]
        public string GetFelhasznaloJelszo(int id,int type)
        {
            switch (type)
            {
                case 1:
                    Tanulo tan = _context.Tanulok.Where(x => x.ID == id).First();
                    string _salt = tan.P_Salt;
                    return _salt;

                case 2:
                    Tanar tanar = _context.Tanarok.Where(x => x.ID == id).First();
                    string t_salt = tanar.P_Salt;
                    return t_salt;
                default:
                    return "";
            }
        }

        [HttpGet("ellenorzes")]
        public string JelszoEllenorzo(int id, int type)
        {
            switch (type)
            {
                case 1:
                    Tanulo tan = _context.Tanulok.Where(x => x.ID == id).First();
                    string _hash = tan.P_Hash;
                    return _hash;
                case 2:
                    Tanar tanar = _context.Tanarok.Where(x => x.ID == id).First();
                    string t_hash = tanar.P_Hash;
                    return t_hash;
                default:
                    return "";
            }
        }
    }
}
