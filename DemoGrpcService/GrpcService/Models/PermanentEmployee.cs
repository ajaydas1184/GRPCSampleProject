using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Models
{
    public class PermanentEmployee:Employee
    {
        [Column(Order = 7)]
        public int MonthlySalary { get; set; }
    }
}
