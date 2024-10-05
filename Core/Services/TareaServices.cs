using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TareaServices
    {
        private readonly ITareasRepository tareasRepository;

        public TareaServices(ITareasRepository tareasRepository)
        {
            this.tareasRepository = tareasRepository;
        }

        public async Task <IEnumerable<Tareas>> GetTareaByIdUserAsync(int idUser)
        {
            return await tareasRepository.GetTareaByIdUserAsync(idUser);
        }
        public async Task<Tareas> CreateTareaAsync(Tareas tareas)
        {
            return await tareasRepository.CreateTareaAsync(tareas);
        }
        public async Task<TareaDto> UpdateUserAsync(int id,TareaDto tareaDto)
        {
            return await tareasRepository.UpdateUserAsync(id,tareaDto);
        }
        
    }
}
