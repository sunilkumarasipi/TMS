using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace TMS.Data.Models
{
   public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(5)]
        public string Class { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        //foreign key
        [Required]
        public int SchoolId { get; set; }
        public School School { get; set; }

        [Required]
        [StringLength(50)]
        public string GuardianName { get; set; }

        [Required]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fees { get; set; }

        public string Photo { get; set; }

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
