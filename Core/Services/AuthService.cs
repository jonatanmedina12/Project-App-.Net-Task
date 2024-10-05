using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AuthService
    {
        public readonly IUserRepository UserRepository;

        private readonly IConfiguration configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            UserRepository = userRepository;
            this.configuration = configuration;
        }

        public async Task<User> RegisterAsync(string Username, string Email, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Username = Username,
                Email = Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedOn = DateTime.UtcNow
                
            };



            return await UserRepository.CreateUserAsync(user);



        }


        public async Task<string>LoginAsync(string username,string password)
        {

            var user = await UserRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifiPasswordHash(password,user.PasswordHash,user.PasswordSalt)) {

                return null;
                
            }
            user.LastLogin = DateTime.UtcNow;   

            return CreateToken(user);


            
        }



        public bool VerifiPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i]) return false;
            }
            return true;

        } 
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));



        }

        private string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            
            return tokenHandler.WriteToken(token);


        }

        public async Task<User> GetInfoUser(int id )
        {
            return await UserRepository.GetInfoUser(id);

        }
        public async Task<UpdateProfileDto> UpdateUserAsync(int id , UpdateProfileDto updateProfileDto)
        {
            return await UserRepository.UpdateUserAsync(id, updateProfileDto);

        }





    }
}

