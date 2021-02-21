using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.DTO.Auth;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Models
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _repo;

        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }
        public async Task<User> Register(RegisterAndLoginDTO dto)
        {
            return await _repo.Register(dto);
        }

        public async Task<User> Login(RegisterAndLoginDTO dto)
        {
            return await _repo.Login(dto);
        }
    }
}