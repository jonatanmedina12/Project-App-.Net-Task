using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

           return user;
        }

        public async Task<User> GetInfoUser(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        }

        public async  Task<User> GetUserByUsernameAsync(string username)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }


       
        public  async Task<UpdateProfileDto> UpdateUserAsync(int id, UpdateProfileDto updateProfileDto )
        {

            var userFind = await dbContext.Users.FindAsync(id);

            if (userFind == null)
            {
                return null ;
            }
            userFind.UpdateOn = DateTime.Now;
            userFind.Country = updateProfileDto.Country;
            userFind.Email = updateProfileDto.Email;
            userFind.Photo = updateProfileDto.Photo;
            userFind.PhoneNumber= updateProfileDto.PhoneNumber;

            dbContext.Entry(userFind).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
            return updateProfileDto;


        }

     
    }
}
