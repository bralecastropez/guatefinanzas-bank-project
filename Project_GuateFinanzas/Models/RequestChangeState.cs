using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_GuateFinanzas.Models
{
    public abstract class RequestChangeState
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }

        [Required]
        public Enumeration.RequestChangeStatus Request { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string ChangeReason { get; set; }
    }
}