using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register (User user,string password); // We have to store the passwordHash and passwordSalt that's why we are storing the User itself
         Task<User> Login(string username,string password);
         Task<bool> UserExists(string username);

         
    }
}