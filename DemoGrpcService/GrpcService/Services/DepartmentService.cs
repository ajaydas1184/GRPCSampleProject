using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService.Data;
using GrpcService.Models;
using Microsoft.Extensions.Options;

namespace GrpcService.Services
{
    public class DepartmentService : RemoteDepartment.RemoteDepartmentBase
    {
        private IOptions<DBConnection> _dbConnection;
        private readonly ILogger<DepartmentService> _logger;
        public DepartmentService(ILogger<DepartmentService> logger, IOptions<DBConnection> dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }

        public override Task<DepartmentResponse> AddEditRecord(DepartmentModel request, ServerCallContext context)
        {
            try
            {
                int saveStatus = 0;
                string msg = "";
                using (DataContext dataContext = new DataContext(_dbConnection))
                {
                    Department model = new Department()
                    {
                        Id = request.Id != 0 ? request.Id : 0,
                        Name = request.Name.Trim()
                    };

                    if (model.Id > 0)
                    {
                        var dept = dataContext.Departments.Find(model.Id);
                        dept.Name = model.Name;
                    }
                    else if (model.Id == 0)
                    {
                        dataContext.Departments.Add(model);
                    }

                    saveStatus = dataContext.SaveChanges();
                }

                msg = "Department records has been updated successfully";
                _logger.LogInformation(msg);
                return Task.FromResult(new DepartmentResponse
                {
                    RetVal = saveStatus,
                    MSG = msg
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentService.AddEditRecord - Error: {0}", ex.Message);
                return Task.FromResult(new DepartmentResponse
                {
                    RetVal = -1,
                    MSG = ex.Message
                });
            }
        }

        public override Task<DepartmentResponse> DeleteRecord(DepartmentRequest request, ServerCallContext context)
        {
            try
            {
                int saveStatus = 0;
                string msg = "";
                using (DataContext dataContext = new DataContext(_dbConnection))
                {
                    if (request.Id > 0)
                    {
                        var dept = dataContext.Departments.Find(request.Id);
                        if (dept != null)
                        {
                            if (dept.Employees.Count == 0)
                            {
                                dataContext.Departments.Remove(dept);
                                saveStatus = dataContext.SaveChanges();
                                msg = "Department record has been deleted successfully";
                            }
                            else
                            {
                                msg = "The record is already present on the children's table. Before performing this procedure, remove the record from the child table.";
                            }
                        }
                        else
                        {
                            msg = "Record is not found";
                        }
                    }
                }

                _logger.LogInformation(msg);
                return Task.FromResult(new DepartmentResponse
                {
                    RetVal = saveStatus,
                    MSG = msg
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentService.DeleteRecord - Error: {0}", ex.Message);
                return Task.FromResult(new DepartmentResponse
                {
                    RetVal = -1,
                    MSG = ex.Message
                });
            }
        }

        public override Task<DepartmentModel> GetDepartmentInfo(DepartmentRequest request, ServerCallContext context)
        {
            DepartmentModel model = new DepartmentModel();
            try
            {
                using (DataContext dataContext = new DataContext(_dbConnection))
                {

                    var dept = dataContext.Departments.FirstOrDefault(x => x.Id == request.Id);
                    if (dept != null)
                    {
                        model.Id = dept.Id;
                        model.Name = dept.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentService.GetDepartmentInfo - Error: {0}", ex.Message);
            }
            return Task.FromResult(model);
        }

        public override Task<DepartmentsResponse> GetDepartmentList(DepartmentRequest request, ServerCallContext context)
        {
            DepartmentsResponse responseData = new DepartmentsResponse();
            try
            {
                using (DataContext dataContext = new DataContext(_dbConnection))
                {

                    var query = (from s in dataContext.Departments
                                 where (request.Id == 0 || s.Id == request.Id) && (request.Name == "" || s.Name.Contains(request.Name))
                                 select new DepartmentModel
                                 {
                                     Id = s.Id,
                                     Name = s.Name
                                 });

                    responseData.Items.AddRange(query.ToArray());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentService.GetDepartmentList - Error: {0}", ex.Message);
            }
            return Task.FromResult(responseData);
        }
    }
}
