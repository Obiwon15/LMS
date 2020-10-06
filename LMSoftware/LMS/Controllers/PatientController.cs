using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data.Interfaces;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedLaboratorySystem.Controllers
{
   
    [Authorize]
    public class PatientController : Controller
    {
        // GET: PatientController
        private IRepository _repository;
        private readonly AppDbContext _ctx;

        public PatientController(IRepository repository, AppDbContext ctx)
        {
            _repository = repository;
            _ctx = ctx;
        }
        public ActionResult Index()
        {
            var pat = _repository.GetAllPatients();
            return View(pat);
        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            var pat = _repository.GetPatient(id);
            return View(pat);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            var docList = (from doc in _ctx.Physicians
                            select new SelectListItem()
                            {
                                Text = doc.PhysicianName,
                                Value = doc.Id.ToString(),
                            }).ToList();
            docList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });

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

            PatientViewModel vm = new PatientViewModel();
            vm.docL = docList;
            vm.tesL = tesList;


            return View(vm);
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientViewModel vm, IFormCollection collection)
        {
            var pvm = new PatientForm
            {
                Fullname = vm.Fullname,
                //Department = vm.Department,
                Age = vm.Age,
              
                ClinicalDiagnosis = vm.ClinicalDiagnosis,
                DateOfRequest = vm.DateOfRequest,
                ClinicNo = vm.ClinicNo,
               //Test = new PatientTest {
                  testId = vm.TestId,
                  
               //},
               //PhysicianId = vm.PhysicianId,
               DepartmentId = vm.DepartmentId,
               PhysicianId = vm.PhysicianId
            };

            try
            {
              
                _repository.AddPatient(pvm);

                await _repository.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id, int TestId)
        {
            //var docList = (from doc in _ctx.Physicians
            //               select new SelectListItem()
            //               {
            //                   Text = doc.PhysicianName,
            //                   Value = doc.Id.ToString(),
            //               }).ToList();
            //docList.Insert(0, new SelectListItem()
            //{
            //    Text = "---Select---",
            //    Value = string.Empty
            //});

            if (id == 0)
            {
              
                PatientViewModel vm = new PatientViewModel();
                //vm.docL = docList;
                return View(vm);
            }
            else
            {
                var patient = _repository.GetPatient(id);
                //var physician = _repository.GetPhysician(id);
                return View(new PatientViewModel
                {
                    Id = patient.Id,
                    Fullname = patient.Fullname,
                    Age = patient.Age,
                    //Department = patient.Department,
                    TestId = patient.DepartmentId,
                    
                   //docL = docList,
                    ClinicNo = patient.ClinicNo,
                    DateOfRequest = patient.DateOfRequest,
                    ClinicalDiagnosis = patient.ClinicalDiagnosis,
               DepartmentId = patient.DepartmentId,
                    PhysicianId = patient.PhysicianId,
                    
                    //Physician = physician.PhysicianName
                }
                    );
            }
        }

        // POST: PatientController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(int id, PatientViewModel vm, IFormCollection collection)
        {
            var patient = new PatientForm
            {
                Id = vm.Id,
                Fullname = vm.Fullname,
               
                Age = vm.Age,
                //Department = vm.Department,
                ClinicalDiagnosis = vm.ClinicalDiagnosis,
                ClinicNo = vm.ClinicNo,
                DateOfRequest = vm.DateOfRequest,
                DepartmentId = vm.DepartmentId,
               PhysicianId = vm.PhysicianId,
               
                //Test = new PatientTest
                //{
                    testId = vm.TestId
             
            };
            try
            {
             
                //if (vm.Image == null)
                //{
                //    post.Image = vm.CurrentImage;
                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(vm.CurrentImage))
                //    {
                //        _fileMgr.RemoveImage(vm.CurrentImage);
                //    }
                //    post.Image = await _fileMgr.SaveImage(vm.Image);
                //}

                if (patient.Id > 0)
                {
                    _repository.UpdatePatient(patient);
                }
                else
                {
                    _repository.AddPatient(patient);
                }
                await _repository.SaveChangesAsync();
                  
                return RedirectToAction("Index");
            }
            catch
            {
                return View(patient);
            }
        }

        // GET: PatientController/Delete/5
        //public ActionResult Delete(int id)
        //{

        //    return View();
        //}

        // POST: PatientController/Delete/5

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            //try
            //{
            var pat = _repository.GetPatient(id);

                _repository.RemovePatient(pat);
                await _repository.SaveChangesAsync();

            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View("Index");
            //}
        }
    }
}
