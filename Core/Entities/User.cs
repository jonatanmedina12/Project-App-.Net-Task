using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Dato requerido {0}")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Dato requerido {0}")]

        public string Email { get; set; }


        public string Photo {  get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }   

        public DateTime CreatedOn { get; set; }

        public DateTime UpdateOn { get; set; }

        public DateTime LastLogin { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt {  get; set; }

        public List<Tareas> Tareas { get; set; }


    }
}
