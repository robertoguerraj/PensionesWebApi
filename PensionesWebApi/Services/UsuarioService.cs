using Microsoft.IdentityModel.Tokens;
using PensionesWebApi.EntityFramework;
using PensionesWebApi.Helpers;
using PensionesWebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PensionesWebApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private PensionesDBContext _context;
        public UsuarioService(PensionesDBContext context)
        {
            _context = context;
        }

        public bool PasswordValidation(string password, Usuario usuario)
        {
            // check if password is correct
            if (!VerifyPasswordHash(password, usuario.PasswordHash, usuario.PasswordSalt))
                return false;

            // authentication successful
            return true;
        }

        public string GetJsonToken(int id, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Usuario GetUserProperties(Usuario user, string password)
        {
            var username = user.Nombre.Substring(0, 3) + user.Apellidos.Substring(0, 3);
            if (_context.Usuarios.Any(x => x.Email == user.Email))
                throw new AppException("El correo " + user.Email + " ya está registrado.");
            if (_context.Usuarios.Any(x => x.UserName == username))
                username = username + 1;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.TemporalPassword = true;
            user.UserName = username;
            user.Activo = true;

            return user;
        }

        public Usuario ForgotPassword(string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var usuario = new Usuario();
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;
            usuario.TemporalPassword = true;

            return usuario;
        }

        public Usuario UpdatePassword(Password password)
        {
            var userExist = _context.Usuarios.Any(u => u.UsuarioId == password.UsuarioId);

            if (!userExist)
                throw new AppException("Usuario no encontrado");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password.NewPassword, out passwordHash, out passwordSalt);

            var user = new Usuario();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.TemporalPassword = false;

            return user;
        }

        public Usuario GetUserById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public string CreateTemporalPassword()
        {
            int length = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}
