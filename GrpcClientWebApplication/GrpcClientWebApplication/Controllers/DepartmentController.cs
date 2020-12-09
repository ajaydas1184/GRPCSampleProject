using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GrpcClientWebApplication.Controllers
{
    public class DepartmentController : BaseController
    {
        private RemoteDepartment.RemoteDepartmentClient _DptClient { get { return new RemoteDepartment.RemoteDepartmentClient(_GrpcChannel); } }

        // GET: DepartmentController
        public ActionResult Index()
        {
            DepartmentsResponse model = _DptClient.GetDepartmentList(new DepartmentRequest());
            return View(model);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            DepartmentModel model = new DepartmentModel();
            return View(model);
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentResponse response = _DptClient.AddEditRecord(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentModel model = new DepartmentModel();
            model = _DptClient.GetDepartmentInfo(new DepartmentRequest() { Id = id });
            return View(model);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentResponse response = _DptClient.AddEditRecord(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        //[HttpPost]
        public JsonResult Delete(string id)
        {
            DepartmentResponse response = _DptClient.DeleteRecord(new DepartmentRequest() { Id = Int32.Parse(id) });
            return Json(response);
        }
    }
}
