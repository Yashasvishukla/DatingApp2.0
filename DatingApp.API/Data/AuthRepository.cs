using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbcontext;
        public AuthRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x=>x.Username.Equals(username));
            if(user==null){
                return null;
            }

            if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt)) 
                return null;
            
            return user;


        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0;i<computedHash.Length;i++){
                    if(computedHash[i]!=passwordHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash,passwordSalt;
            ComputePasswordHash(password,out passwordHash,out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return user;
        }

        private void ComputePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if( await _dbcontext.Users.AnyAsync(x=>x.Username.Equals(username))) return true;

            return false;
        }
    }
}