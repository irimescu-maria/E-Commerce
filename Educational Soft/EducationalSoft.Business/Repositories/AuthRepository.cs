using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EducationalSoft.Data.DataAccess;
using EducationalSoft.Model.Entities;

namespace EducationalSoft.Business.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EducationalSoftDbContext _context;

        public AuthRepository(EducationalSoftDbContext context)
        {
            _context = context;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPassword(password, user.Password, user.ConfirmPassword))
                return null;
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
 

        public User Register(User user, string password)
        {
            byte[] passwordSalt, passwordHash;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Password = passwordHash.ToString();
            user.ConfirmPassword = passwordSalt.ToString();

            _context.Users.Add(user);
            return user;
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}