using System;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.DTO.Auth;
using DataLayer.Interfaces;
using DataLayer.Models;
using NotImplementedException = System.NotImplementedException;

namespace DataLayer.Repositories
{
    public class AuthRepository:BaseContext,IAuthRepository
    {
        public AuthRepository(ShopContext ctx) : base(ctx)
        {
            
        }

        public async Task<User> Register(RegisterAndLoginDTO dto)
        {
            try
            {
                var user = new User()
                {
                    Username = dto.Username,
                    Password = dto.Password
                };
                ctx.Users.Add(user);
                await SaveAsync();
                return user;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Login(RegisterAndLoginDTO dto)
        {
            try
            {
                var user = await ctx.Users.FindAsync(dto.Username);
                return user;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}