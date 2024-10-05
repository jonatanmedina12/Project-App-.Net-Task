using Core.Dtos;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_App_Task.Controllers
{

    public class TareasController : BaseController
    {

        private readonly TareaServices tareaServices;

        public TareasController(TareaServices tareaServices)
        {
            this.tareaServices = tareaServices;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTask(Tareas tareas)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Datos de tarea no validos", errors = ModelState });

                }
                var createdTask =await tareaServices.CreateTareaAsync(tareas);
                return CreatedAtAction(nameof(GetTask), new { id = createdTask.IdUser }, createdTask);


            }
            catch (Exception ex)
            {

                 return StatusCode(500, new { message = "¡Se produjo un error durante la creación!.", error = ex.Message });

            }

        }

        [Authorize]
        [HttpGet("id")]
        public async Task <ActionResult<Tareas>> GetTask(int id)
        {
            try
            {
                var task_id = await tareaServices.GetTareaByIdUserAsync(id);
                if (task_id == null)
                {
                    return NotFound(new { menssage = "Tarea no encontrado" });

                }
                return Ok(task_id);

            }
            catch (Exception ex )
            {

                return StatusCode(500, new { message = "¡Se produjo un error durante la busquedad !.", error = ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> updateTarea(int id, TareaDto tareaDto)
        {
            try
            {
                var tareaUpdate = await tareaServices.UpdateUserAsync(id, tareaDto);
                if (tareaUpdate == null)
                {
                    return NotFound(new { menssage = "Tarea no encontrado" });
                }
                return Ok(new { message = "Se actualizo correctamente", tareaUpdate = tareaUpdate }
                );

            }

            catch (Exception ex)
            {

                return StatusCode(500, new { message = "¡Se produjo un error durante la actualización!.", error = ex.Message });
            }

        }

    }
}
