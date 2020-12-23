using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrpcClientWebApplication.Controllers
{
    public class EmployeeController : BaseController
    {
        private RemoteEmployee.RemoteEmployeeClient _empClient { get { return new RemoteEmployee.RemoteEmployeeClient(_GrpcChannel); } }
        private RemoteDepartment.RemoteDepartmentClient _DptClient { get { return new RemoteDepartment.RemoteDepartmentClient(_GrpcChannel); } }
        // GET: EmployeeController
        public ActionResult Index(string? type)
        {
            EmployeesResponse model = _empClient.GetEmployeeList(new FilterRequest() { EmployeeType = type ?? string.Empty });
            ViewBag.EmpType = type;
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            EmployeeModel model = new EmployeeModel();
            var deptList = _DptClient.GetDepartmentList(new DepartmentRequest());

            List<SelectListItem> ObjList = new List<SelectListItem>();
            foreach (var item in deptList.Items)
            {
                var value = new SelectListItem { Text = item.Name, Value = item.Id.ToString() };
                ObjList.Add(value);
            };

            ViewBag.DepartmentList = ObjList;
            return View(model);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel model)
        {
            try
            {               

                if (ModelState.IsValid)
                {
                    EmployeeResponse employeeResponse = _empClient.AddEditRecord(model);
                    return RedirectToAction("Index");
                }

                var deptList = _DptClient.GetDepartmentList(new DepartmentRequest());
                List<SelectListItem> ObjList = new List<SelectListItem>();
                foreach (var item in deptList.Items)
                {
                    var value = new SelectListItem { Text = item.Name, Value = item.Id.ToString() };
                    ObjList.Add(value);
                };

                ViewBag.DepartmentList = ObjList;
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel model = _empClient.GetEmployeeInfo(new FilterRequest() { Id = id });
            var deptList = _DptClient.GetDepartmentList(new DepartmentRequest());
            List<SelectListItem> ObjList = new List<SelectListItem>();
            foreach (var item in deptList.Items)
            {
                var value = new SelectListItem { Text = item.Name, Value = item.Id.ToString() };
                ObjList.Add(value);
            };

            ViewBag.DepartmentList = ObjList;
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    EmployeeResponse employeeResponse = _empClient.AddEditRecord(model);
                    return RedirectToAction("Index");
                }

                var deptList = _DptClient.GetDepartmentList(new DepartmentRequest());
                List<SelectListItem> ObjList = new List<SelectListItem>();
                foreach (var item in deptList.Items)
                {
                    var value = new SelectListItem { Text = item.Name, Value = item.Id.ToString() };
                    ObjList.Add(value);
                };

                ViewBag.DepartmentList = ObjList;
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public JsonResult Delete(string id)
        {
            EmployeeResponse response = _empClient.DeleteRecord(new FilterRequest() { Id = Int32.Parse(id) });
            return Json(response);
        }
    }
}
