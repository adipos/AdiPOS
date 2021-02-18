using Api.Database.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity
{
    public class ApplicationUser : IdentityUser<string>, IEntityBase<string>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TypeIdentificationId { get; set; }
        public string Identification { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
