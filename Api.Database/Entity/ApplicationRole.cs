using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public ApplicationRole(string name)
        {
            Name = name;
        }
        public ApplicationRole(string name, string Descripcion)
        {
            Name = name;
            this.Descripcion = Descripcion;
        }

        public string Descripcion { get; set; }
    }
}
