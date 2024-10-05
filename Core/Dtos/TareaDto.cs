using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class TareaDto
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }

        public bool Completed { get; set; }
  


    }
}
