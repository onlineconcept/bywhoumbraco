using System.Threading.Tasks;
using DataLayer.DTO.Auth;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(RegisterAndLoginDTO dto);
        Task<User> Login(RegisterAndLoginDTO dto);
    }
}