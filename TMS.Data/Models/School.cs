using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace TMS.Data.Models
{
   public class School
    {
        [Key]
        public int SchoolId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        [StringLength(100)]
        public string Comments { get; set; }

        [Required]
        public int InsBy { get; set; }

        [Required]
        public DateTime InsDate { get; set; }

        public int? ModiBy { get; set; }

        public DateTime? ModiDate { get; set; }

        public int? DelBy { get; set; }

        public DateTime? DelDate { get; set; }

        [Required]
        [StringLength(1)]
        public string DelStatus { get; set; }

    }
}
