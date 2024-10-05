using Core.Dtos;
using Core.Services;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_App_Task.Controllers
{
 
    public class AccountController : BaseController
    {

        private readonly AuthService authService;

        public AccountController(AuthService authService)
        {
            this.authService = authService;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult>updateUser(int id, UpdateProfileDto updateProfileDto)
        {
            try
            {
                var updateUser = await authService.UpdateUserAsync(id, updateProfileDto);
                if (updateUser == null)
                {
                    return NotFound(new {menssage="Usuario no encontrado" });
                }
                return Ok(new {message ="Se actualizo correctamente" , updateUser = updateUser }
                );

            }

            catch (Exception ex)
            {

                return StatusCode(500, new { message = "¡Se produjo un error durante la actualización!.", error = ex.Message });
            }

        }


    }
}
