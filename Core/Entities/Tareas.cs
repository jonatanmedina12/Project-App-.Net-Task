using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Tareas
    {

        public int Id {  get; set; }

        [Required(ErrorMessage ="Dato requerido {0}")]
        
        public string Name { get; set; }

       public string Description { get; set; }  

       public bool Completed { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdateOn { get; set; }


        public int IdUser {  get; set; }

        [JsonIgnore]

        [ForeignKey("Id")]
       public User User { get; set; }  



    }
}
