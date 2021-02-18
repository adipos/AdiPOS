using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dto
{
    public class ApplicationUserDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }        
        public int TypeIdentificationId { get; set; }
        public string Identification { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
