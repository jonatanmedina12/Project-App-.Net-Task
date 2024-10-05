using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UpdateProfileDto
    {

        [EmailAddress(ErrorMessage ="Incorrecto {0}")]
       
        public string Email { get; set; }

        public string Photo { get; set; }

        [StringLength(maximumLength:20,MinimumLength =5)]
        public string Country { get; set; }

        [Phone]
        [StringLength(maximumLength:20,MinimumLength =10)]
        public string PhoneNumber { get; set; }


    }
}
