using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dto
{
    public class LoginResponseDTO
    {
        public string Id { get; set; }
        public string AuthToken { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
