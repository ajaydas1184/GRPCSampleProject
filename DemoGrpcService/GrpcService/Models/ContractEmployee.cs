using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Models
{
    public class ContractEmployee : Employee
    {
        [Column(Order = 8)]
        public int HoursWorked { get; set; }
        [Column(Order = 9)]
        public int HourlyPay { get; set; }
    }
}
