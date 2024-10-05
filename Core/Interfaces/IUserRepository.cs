using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {

        Task<User> GetUserByUsernameAsync(string username);

        Task<User> CreateUserAsync(User user);

        Task<User> GetInfoUser(int id);

        Task<UpdateProfileDto> UpdateUserAsync(int id, UpdateProfileDto updateProfileDto);









    }
}
