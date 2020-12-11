using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Models
{
    [Table("tbl_Employee")]
    public class Employee
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Required]
        [Column(Order = 2)]
        public string FirstName { get; set; }
        [Required]
        [Column(Order = 3)]
        public string LastName { get; set; }
        [Required]
        [Column(Order = 4)]
        public string Gender { get; set; }
        [Required]
        [Column(Order = 5)]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [ForeignKey("Department")]
        [Column(Order = 6)]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
