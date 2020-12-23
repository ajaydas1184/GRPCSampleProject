using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Data;
using GrpcService.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GrpcService
{
    public class EmployeeService : RemoteEmployee.RemoteEmployeeBase
    {
        private IOptions<DBConnection> _dbConnection;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(ILogger<EmployeeService> logger, IOptions<DBConnection> dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }

        public override Task<EmployeeResponse> AddEditRecord(EmployeeModel request, ServerCallContext context)
        {
            try
            {
                int saveStatus = 0;
                string msg = "";
                using (DataContext dataContext = new DataContext(_dbConnection))
                {
                    if (request.EmployeeType.ToLower() == "permanent")
                    {
                        PermanentEmployee permanent = new PermanentEmployee
                        {
                            Id = request.Id != 0 ? request.Id : 0,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            DateOfJoining = new DateTime(2010, 04, 11),
                            Gender = request.Gender,
                            DepartmentId = request.DepartmentId,
                            MonthlySalary = request.MonthlySalary
                        };

                        if (permanent.Id > 0)
                        {
                            var emp = dataContext.Employees.Find(permanent.Id);

                            emp.FirstName = permanent.FirstName;
                            emp.LastName = permanent.LastName;
                            emp.DateOfJoining = permanent.DateOfJoining;
                            emp.Gender = permanent.Gender;
                            emp.DepartmentId = permanent.DepartmentId;
                            ((PermanentEmployee)emp).MonthlySalary = permanent.MonthlySalary;
                        }
                        else if (permanent.Id == 0)
                        {
                            dataContext.Employees.Add(permanent);
                        }

                        saveStatus = dataContext.SaveChanges();
                    }
                    else if (request.EmployeeType.ToLower() == "contract")
                    {
                        ContractEmployee contract = new ContractEmployee
                        {
                            Id = request.Id != 0 ? request.Id : 0,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            DateOfJoining = new DateTime(2010, 04, 11),
                            Gender = request.Gender,
                            DepartmentId = request.DepartmentId,
                            HourlyPay = request.HourlyPay,
                            HoursWorked = request.HoursWorked
                        };

                        if (contract.Id > 0)
                        {
                            var emp = dataContext.Employees.Find(contract.Id);

                            emp.FirstName = contract.FirstName;
                            emp.LastName = contract.LastName;
                            emp.DateOfJoining = contract.DateOfJoining;
                            emp.Gender = contract.Gender;
                            emp.DepartmentId = contract.DepartmentId;
                            ((ContractEmployee)emp).HourlyPay = contract.HourlyPay;
                            ((ContractEmployee)emp).HoursWorked = contract.HoursWorked;
                        }
                        else if (contract.Id == 0)
                        {
                            dataContext.Employees.Add(contract);
                        }

                        saveStatus = dataContext.SaveChanges();
                    }
                }

                msg = "Employee records has been updated successfully";
                _logger.LogInformation(msg);
                return Task.FromResult(new EmployeeResponse
                {
                    RetVal = saveStatus,
                    MSG = msg
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeService.AddEditRecord - Error: {0}", ex.Message);
                return Task.FromResult(new EmployeeResponse
                {
                    RetVal = -1,
                    MSG = ex.Message
                });
            }
        }
        public override Task<EmployeeResponse> DeleteRecord(FilterRequest request, ServerCallContext context)
        {
            try
            {
                int saveStatus = 0;
                string msg = "";
                using (DataContext dataContext = new DataContext(_dbConnection))
                {
                    if (request.Id > 0)
                    {
                        var employee = dataContext.Employees.Find(request.Id);
                        if (employee != null)
                        {
                            dataContext.Employees.Remove(employee);
                            saveStatus = dataContext.SaveChanges();
                            msg = "Employees record has been deleted successfully";
                        }
                        else
                        {
                            msg = "Record is not found";
                        }
                    }
                }

                _logger.LogInformation(msg);
                return Task.FromResult(new EmployeeResponse
                {
                    RetVal = saveStatus,
                    MSG = msg
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeService.DeleteRecord - Error: {0}", ex.Message);
                return Task.FromResult(new EmployeeResponse
                {
                    RetVal = -1,
                    MSG = ex.Message
                });
            }
        }
        public override Task<EmployeesResponse> GetEmployeeList(FilterRequest request, ServerCallContext context)
        {
            EmployeesResponse responseData = new EmployeesResponse();
            try
            {
                using (DataContext dataContext = new DataContext(_dbConnection))
                {
                    switch (request.EmployeeType.ToLower())
                    {
                        case "permanent":
                            var perEmp = (from s in dataContext.Employees.OfType<PermanentEmployee>()
                                          where (request.Id == 0 || s.Id == request.Id) && (request.Name == "" || s.FirstName.Contains(request.Name))
                                          && (request.Name == "" || s.LastName.Contains(request.Name))
                                          select new EmployeeModel
                                          {
                                              Id = s.Id,
                                              FirstName = s.FirstName,
                                              LastName = s.LastName,
                                              DateOfJoining = s.DateOfJoining.ToString(),
                                              Gender = s.Gender,
                                              DepartmentId = s.DepartmentId,
                                              MonthlySalary = s.MonthlySalary,
                                              EmployeeType = "Permanent",
                                              DepartmentName = s.Department.Name
                                          });

                            responseData.Items.AddRange(perEmp.ToArray());
                            break;

                        case "contract":
                            var contraEmp = (from s in dataContext.Employees.OfType<ContractEmployee>()
                                             where (request.Id == 0 || s.Id == request.Id) && (request.Name == "" || s.FirstName.Contains(request.Name))
                                             && (request.Name == "" || s.LastName.Contains(request.Name))
                                             select new EmployeeModel
                                             {
                                                 Id = s.Id,
                                                 FirstName = s.FirstName,
                                                 LastName = s.LastName,
                                                 DateOfJoining = s.DateOfJoining.ToString(),
                                                 Gender = s.Gender,
                                                 DepartmentId = s.DepartmentId,
                                                 HourlyPay = s.HourlyPay,
                                                 HoursWorked = s.HoursWorked,
                                                 EmployeeType = "Contract",
                                                 DepartmentName = s.Department.Name
                                             });

                            responseData.Items.AddRange(contraEmp.ToArray());
                            break;
                        default:
                            var emp = (from s in dataContext.Employees
                                       where (request.Id == 0 || s.Id == request.Id) && (request.Name == "" || s.FirstName.Contains(request.Name))
                                       && (request.Name == "" || s.LastName.Contains(request.Name))
                                       select s).ToList();
                            List<EmployeeModel> empList = new List<EmployeeModel>();
                            foreach (var s in emp)
                            {
                                var model = new EmployeeModel()
                                {
                                    Id = s.Id,
                                    FirstName = s.FirstName,
                                    LastName = s.LastName,
                                    DateOfJoining = s.DateOfJoining.ToString(),
                                    Gender = s.Gender,
                                    DepartmentId = s.DepartmentId,
                                    MonthlySalary = (s is PermanentEmployee ? ((PermanentEmployee)s).MonthlySalary : 0),
                                    HourlyPay = (s is ContractEmployee ? ((ContractEmployee)s).HourlyPay : 0),
                                    HoursWorked = (s is ContractEmployee ? ((ContractEmployee)s).HoursWorked : 0),
                                    EmployeeType = (s is PermanentEmployee ? "Permanent" : "Contract"),
                                    DepartmentName = s.Department.Name
                                };
                                empList.Add(model);
                            }
                            responseData.Items.AddRange(empList.ToArray());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentService.GetDepartmentList - Error: {0}", ex.Message);
            }
            return Task.FromResult(responseData);
        }

        public override Task<EmployeeModel> GetEmployeeInfo(FilterRequest request, ServerCallContext context)
        {
            EmployeeModel empModel = new EmployeeModel();

            try
            {
                using (DataContext dataContext = new DataContext(_dbConnection))
                {
                    var employee = dataContext.Employees.Find(request.Id);

                    empModel.Id = employee.Id;
                    empModel.FirstName = employee.FirstName;
                    empModel.LastName = employee.LastName;
                    empModel.DateOfJoining = employee.DateOfJoining.ToString();
                    empModel.Gender = employee.Gender;
                    empModel.DepartmentId = employee.DepartmentId;
                    empModel.MonthlySalary = (employee is PermanentEmployee ? ((PermanentEmployee)employee).MonthlySalary : 0);
                    empModel.HourlyPay = (employee is ContractEmployee ? ((ContractEmployee)employee).HourlyPay : 0);
                    empModel.HoursWorked = (employee is ContractEmployee ? ((ContractEmployee)employee).HoursWorked : 0);
                    empModel.EmployeeType = (employee is ContractEmployee ? "Permanent" : "Contract");
                    empModel.DepartmentName = employee.Department.Name;

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentService.GetEmployeeInfo - Error: {0}", ex.Message);
            }
            return Task.FromResult(empModel);
        }
    }
}
