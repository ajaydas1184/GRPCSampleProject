using GrpcService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            AddDepartments(context);
            AddEmployeess(context);
            base.Seed(context);
        }

        private void AddDepartments(DataContext context)
        {
            var departments = new List<Department>
            {
                new Department { Name = "HR", Id=1 },
                new Department { Name = "Administrator", Id=2 },
                new Department { Name = "IT", Id=3 },
                new Department { Name = "Account", Id=4 }
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();
        }

        private void AddEmployeess(DataContext context)
        {
            var permanentEmps = new List<PermanentEmployee>
            {
                new PermanentEmployee { Id=1, FirstName="lakshmi",LastName="Palanivel",DateOfJoining=new DateTime(2010,04,11),Gender="Female",DepartmentId=1,MonthlySalary=48000},
                new PermanentEmployee { Id=2, FirstName="Rabindra Nath",LastName="Das",DateOfJoining=new DateTime(2010,06,15),Gender="Male",DepartmentId=1,MonthlySalary=45500},
                new PermanentEmployee { Id=3, FirstName="Greeshma",LastName="Menon",DateOfJoining=new DateTime(2018,06,15),Gender="Male",DepartmentId=4,MonthlySalary=45500},
                new PermanentEmployee { Id=4, FirstName="Prasenjit",LastName="Adhikari",DateOfJoining=new DateTime(2018,06,15),Gender="Male",DepartmentId=3,MonthlySalary=51500 },
                new PermanentEmployee { Id=5, FirstName="Debasis",LastName="Das",DateOfJoining=new DateTime(2018,08,15),Gender="Male",DepartmentId=3,MonthlySalary=45000 },
                new PermanentEmployee { Id=6, FirstName="Vishal",LastName="Panda",DateOfJoining=new DateTime(2019,04,25),Gender="Male",DepartmentId=3,MonthlySalary=45000 },
            };

            var contractEmps = new List<ContractEmployee>
            {
                new ContractEmployee { Id=7, FirstName="Sandip",LastName="Kundu",DateOfJoining=new DateTime(2015,10,11),Gender="Male",DepartmentId=3,HourlyPay=100,HoursWorked=160 },
                new ContractEmployee { Id=8, FirstName="Tuhin",LastName="Chakraborty",DateOfJoining=new DateTime(2015,06,15),Gender="Male",DepartmentId=3,HourlyPay=100,HoursWorked=160 },
                new ContractEmployee { Id=9, FirstName="Rahul",LastName="Chakraborty",DateOfJoining=new DateTime(2015,06,15),Gender="Male",DepartmentId=4,HourlyPay=120,HoursWorked=160 },
                new ContractEmployee { Id=10, FirstName="Dibya Bikash",LastName="Singh",DateOfJoining=new DateTime(2015,06,15),Gender="Male",DepartmentId=2,HourlyPay=120,HoursWorked=160 },
            };

            permanentEmps.ForEach(s => context.Employees.Add(s));
            contractEmps.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
        }
    }
}
