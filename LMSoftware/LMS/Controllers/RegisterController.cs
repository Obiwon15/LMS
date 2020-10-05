using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data.Interfaces;
//using LMS.Migrations;
using LMS.Models;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ITestRepository _testRepo;
        private readonly IRepository _repo;
        private readonly AppDbContext _ctx;
        public RegisterController(ITestRepository testRepo, IRepository repo, AppDbContext ctx)
        {
            _testRepo = testRepo;
            _repo = repo;
            _ctx = ctx;
        }

        // GET: RegisterController
        public ActionResult Index()
        {

            var res = _testRepo.GetAppointments();
            //var pat = _repo.GetAllPatients();
            //var test

            //AppDeptViewModel vm = new AppDeptViewModel
            //{
            //    patient = pat,
            //    app = res,

            //};
           

            return View(res);
        }

        // GET: RegisterController/Details/5
        public ActionResult AppDetails(int id)
        {
            var pat = _testRepo.GetAppointment(id);
            return View(pat);
        }
        public ActionResult DeptDetails(int id)
        {
            var pat = _testRepo.GetTestDept(id);
            return View(pat);
        }

        // GET: RegisterController/Create
        public ActionResult CreateApp()
        {
            var tesList = (from tes in _ctx.Tests
                           select new SelectListItem()
                           {
                               Text = tes.TestName,
                               Value = tes.TestId.ToString(),
                           }).ToList();
            tesList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });

            var patList = (from pat in _ctx.Patients
                           select new SelectListItem()
                           {
                               Text = pat.Fullname,
                               Value = pat.Id.ToString(),
                           }).ToList();
            patList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            AppDeptViewModel vm = new AppDeptViewModel
            {
                TestL = tesList,
                patL = patList
            };
            return View(vm);
        }
     
        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateApp(AppDeptViewModel vm, IFormCollection collection)
        {
           
            var app = new TestRegister
            {
                Date = DateTime.Now,
                PatientId = vm.PatientId,
                TId = vm.TestId,
                Result = new TestResult
                {
                    Id = vm.ResultId
                }
                
                //Patients = new PatientForm
                //{
                //    Fullname = vm.Fullname,
                //    Age = vm.Age,
                //    ClinicalDiagnosis = vm.ClinicalDiagnosis,
                //    DateOfRequest = vm.DateOfRequest,
                //    Physician = new Physician
                //    {
                //        PhysicianName = vm.Physician
                //    }
                //},
                //Tests = /*(from product in _ctx.Tests new PatientTest)*/{

                    //},

                    //    Result = new TestResult
                    //    {
                    //        IsCompleted = vm.IsCompleted
                    //    },
                
            };
            try
            {
                _testRepo.AddAppointment(app);
               await _testRepo.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(app);
            }
        }
        // GET: RegisterController/Create
        public ActionResult CreateDept()
        {
            return View(new AppDeptViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDept(AppDeptViewModel vm, IFormCollection collection)
        {
            var tes = new TestDepartment
            {
                DeptId = vm.DepartmentId,
                Department = vm.Department
              
                //Patients = new PatientForm
                //{
                //    Fullname = vm.Fullname,
                //    Age = vm.Age,
                //    ClinicalDiagnosis = vm.ClinicalDiagnosis,
                //    DateOfRequest = vm.DateOfRequest,
                //    Physician = new Physician
                //    {
                //        PhysicianName = vm.Physician
                //    }
                //},
                //Tests = /*(from product in _ctx.Tests new PatientTest)*/{

                //},

                //    Result = new TestResult
                //    {
                //        IsCompleted = vm.IsCompleted
                //    },

            };
            try
            {
                _testRepo.AddDepartment(tes);
                await _testRepo.SaveChangesAsync();
                return RedirectToAction("Department", "Home");
            }
            catch
            {
                return View(tes);
            }
        }


        // GET: RegisterController/Edit/5
        public ActionResult EditApp( int id)
        {
            //var tesList = (from tes in _ctx.Tests
            //               select new SelectListItem()
            //               {
            //                   Text = tes.TestName,
            //                   Value = tes.TestId.ToString(),
            //               }).ToList();
            //tesList.Insert(0, new SelectListItem()
            //{
            //    Text = "---Select---",
            //    Value = string.Empty
            //});


            //var patList = (from pat in _ctx.Patients
            //               select new SelectListItem()
            //               {
            //                   Text = pat.Fullname,
            //                   Value = pat.Id.ToString(),
            //               }).ToList();
            //patList.Insert(0, new SelectListItem()
            //{
            //    Text = "---Select---",
            //    Value = string.Empty
            //});
            //AppDeptViewModel vm = new AppDeptViewModel();
            //vm.TestL = tesList;
            //vm.patL = patList;

            if (id == 0)
            {
                return View(new AppDeptViewModel());
            }
            else
            {
                var pat = _repo.GetPatient(id);
                var app = _testRepo.GetAppointment(id);
                var phy = _repo.GetPhysician(id);
                var test = _testRepo.GetTest(id);
                var dept = _testRepo.GetDepartment(id);

                var res = new AppDeptViewModel
                {
                    AppointmentId = app.Id,
                    
                   Fullname = pat.Fullname,
                   Age = pat.Age,
                   TestId = test.TestId,
                   ClinicalDiagnosis = pat.ClinicalDiagnosis,
                   DateOfRequest = pat.DateOfRequest,
                   ClinicNo = pat.ClinicNo,
                   DepartmentId = dept.DeptId,
                   PatientId = pat.Id,
                   Date = app.Date,
                   ResultId = app.ResultId
                   
                };

                return View(res);
            }
        }

        // POST: RegisterController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditApp(AppDeptViewModel vm, int id, IFormCollection collection)
        {
            var tr = new TestRegister
            {
                Id = vm.AppointmentId,
                PatientId = vm.PatientId,
               Date = DateTime.Now,
               TId = vm.TestId,
                Result = new TestResult
                {
                  IsCompleted = vm.IsCompleted
                }
            };
            try
            {
                if (id > 0)
                {
                    _testRepo.UpdateAppointment(tr);
                }
                else
                {
                    _testRepo.AddAppointment(tr);
                }
                _testRepo.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(tr);
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult EditDept(int id)
        {
            if (id == 0)
            {
                return View(new AppDeptViewModel());
            }
            else
            {
               
                var dept = _testRepo.GetDepartment(id);

                var res = new AppDeptViewModel
                {
                    Department = dept.Department,
                 
                    DepartmentId = dept.DeptId,
                  
                };

                return View(res);
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditDept(AppDeptViewModel vm, int id, IFormCollection collection)
        {
            var tr = new TestDepartment
            {
              DeptId = vm.DepartmentId,
              Department = vm.Department,
             
            };
            try
            {
                if (id > 0)
                {
                    _testRepo.UpdateDepartment(tr);
                }
                else
                {
                    _testRepo.UpdateDepartment(tr);
                }
                _testRepo.SaveChangesAsync();
                return RedirectToAction("Department", "Home");
            }
            catch
            {
                return View(tr);
            }
        }

        // GET: RegisterController/Delete/5


        // POST: RegisterController/Delete/5
        [HttpGet]
        public async Task<ActionResult> RemoveApp(int id, IFormCollection collection)
        {
            var test = _testRepo.GetAppointment(id);
           
            try
            {
                _testRepo.RemoveAppointment(test);
                await _testRepo.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // POST: RegisterController/Delete/5
        [HttpGet]
        public async Task<ActionResult> RemoveDept(int id, IFormCollection collection)
        {
            var test = _testRepo.GetDepartment(id);
            try
            {
                _testRepo.RemoveDepartment(test);
                await _testRepo.SaveChangesAsync();
                return RedirectToAction("Department", "Home");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
