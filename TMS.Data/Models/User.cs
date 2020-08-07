using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMS.Data.Models
{
   public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

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
