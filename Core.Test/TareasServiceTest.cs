using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test
{
    public class TareasServiceTest
    {
        private readonly Mock<ITareasRepository> _mockRepo;
        private readonly TareaServices tareaServices;

        public TareasServiceTest(Mock<ITareasRepository> mockRepo, TareaServices tareaServices)
        {
            _mockRepo = mockRepo;
            this.tareaServices = tareaServices;
        }

        public async Task GetTareaById()
        {
            var id = 1;
            var expectedTask = new List<Tareas>
            {
                new Tareas { Id = 1 }
            };
            _mockRepo.Setup(repo => repo.GetTareaByIdUserAsync(id)).ReturnsAsync(expectedTask);

            var result = await tareaServices.GetTareaByIdUserAsync(1);

            Assert.Equal(expectedTask, result);
        }
    }
}
