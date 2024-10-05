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
    public class TareaRepository : ITareasRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TareaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Tareas> CreateTareaAsync(Tareas tareas)
        {
            dbContext.Add(tareas);
            await dbContext.SaveChangesAsync();
            return tareas;
        }

        public async Task<IEnumerable<Tareas>> GetTareaByIdUserAsync(int IdUser)
        {
            return await dbContext.Tareas.Where(c => c.IdUser==IdUser).ToListAsync(); 

        }

        public  async Task<TareaDto> UpdateUserAsync(int id, TareaDto tareaDto)
        {
            var tareaFind = await dbContext.Tareas.FindAsync(id);

            if (tareaFind == null)
            {
                return null;
            }
            tareaFind.UpdateOn = DateTime.Now;
            tareaFind.Description= tareaDto.Description;
            tareaFind.Completed=tareaDto.Completed;
            tareaFind.Name= tareaDto.Name;

            dbContext.Entry(tareaFind).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
            return tareaDto;
        }
    }
}
