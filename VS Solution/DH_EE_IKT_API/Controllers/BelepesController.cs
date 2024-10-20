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
        public bool JelszoEllenorzo(int id, string passHash, int type)
        {
            byte[] passBytes = Encoding.UTF8.GetBytes(passHash);
            switch (type)
            {
                case 1:
                    return TanuloEllenorzes(id, passBytes);
                case 2:
                    return TanarEllenorzes(id, passBytes);
                default:
                    return false;
            }
        }

        private bool TanuloEllenorzes(int id, byte[] passBytes)
        {
            Tanulo tan = _context.Tanulok.Where(x => x.ID == id).First();
            string salt = tan.P_Salt;
            string[] strArray = salt.Split('-');
            byte[] _saltArray = new byte[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                _saltArray[i] = Convert.ToByte(strArray[i], 16);
            }
            Rfc2898DeriveBytes rfc2898DeriveBytes = new(passBytes, _saltArray, 25000, HashAlgorithmName.SHA256);
            byte[] hashByte = rfc2898DeriveBytes.GetBytes(32);
            string newPassHash = BitConverter.ToString(hashByte);
            return newPassHash.Equals(tan.P_Hash);
        }

        private bool TanarEllenorzes(int id, byte[] passBytes)
        {
            Tanar tanar = _context.Tanarok.Where(x => x.ID == id).First();
            string salt = tanar.P_Salt;
            string[] strArray = salt.Split('-');
            byte[] _saltArray = new byte[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                _saltArray[i] = Convert.ToByte(strArray[i], 16);
            }
            Rfc2898DeriveBytes rfc2898DeriveBytes = new(passBytes, _saltArray, 25000, HashAlgorithmName.SHA256);
            byte[] hashByte = rfc2898DeriveBytes.GetBytes(32);
            string newPassHash = BitConverter.ToString(hashByte);
            return newPassHash.Equals(tanar.P_Hash);
        }
    }
}
