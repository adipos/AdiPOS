using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Base
{
    public interface IEntityBase<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public int CreatedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}
