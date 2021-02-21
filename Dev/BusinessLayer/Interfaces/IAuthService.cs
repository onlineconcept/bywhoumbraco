using System.Threading.Tasks;
using DataLayer.DTO.Auth;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(RegisterAndLoginDTO dto);
        Task<User> Login(RegisterAndLoginDTO dto);
    }
}