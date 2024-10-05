using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITareasRepository
    {
        Task<IEnumerable<Tareas>> GetTareaByIdUserAsync(int IdUser);

        Task<Tareas> CreateTareaAsync(Tareas tareas);


        Task<TareaDto> UpdateUserAsync(int id, TareaDto tareaDto);

    }
}

