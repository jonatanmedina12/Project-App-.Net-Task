using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Project_App_Task.Controllers
{
    public class AuthController : BaseController
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Datos de registors invalidos", errors = ModelState });
                }
                var user = await authService.RegisterAsync(registerDto.Username, registerDto.Email, registerDto.Password);
                if (user == null)
                {
                    return BadRequest(new { message = "El registro fallo . es posible que el nombre o el correo ya esten en uso. " });

                }

                return Ok(new { message = "El usuario fue registrado correctamente", user = new { user.Username, user.Email } });

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "¡Se produjo un error durante el registro!.", error = ex.Message } );
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult>Login(LoginDto loginDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Datos de inicio de sesión invalidos", errors = ModelState });
                }

                var token = await authService.LoginAsync(loginDto.Username, loginDto.Password);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized(new { message = "Nombre de usuario o contraseña incorretos" });
                }
                return Ok(new { message = "Inicio de sesión exitoso", token = token });

            }
            catch (Exception ex) 
            {

                return StatusCode(500, new { message = "¡Se produjo un error durante el login !.", error = ex.Message });
            }

        }






    }
}
