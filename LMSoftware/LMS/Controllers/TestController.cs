using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data.Interfaces;
using LMS.Models;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Controllers
{
    public class TestController : Controller
    {
        private ITestRepository _testRepository;
        private IRepository _repository;
        private readonly AppDbContext _ctx;

        public TestController(ITestRepository testRepository, IRepository repository, AppDbContext ctx)
        {
            _testRepository = testRepository;
            _repository = repository;
            _ctx = ctx;
        }
        // GET: TestController
        public ActionResult Index()
        {
            var tes = _testRepository.GetAllTests();
            return View(tes);
        }

        [HttpGet]
        // GET: TestController/Details/5
        public ActionResult TestDetails(int id)
        {

            var tes = _testRepository.GetTestPatients(id);

            if (tes != null)
            {
                return View(tes);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: TestController/Details/5
        public ActionResult DocDetails(int id)
        {

            var tes = _repository.GetPatient(id);

            if (tes != null)
            {
                return View(tes);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: TestController/Create
        public ActionResult CreateTest()
        {
            var deptList = (from dept in _ctx.Departments
                            select new SelectListItem()
                            {
                                Text = dept.Department,
                                Value = dept.DeptId.ToString(),
                            }).ToList();
            deptList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            DoctorTestViewModel vm = new DoctorTestViewModel();
            vm.deptL = deptList;


            return View(vm);
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTest(DoctorTestViewModel vm, IFormCollection collection)
        {

            var pat = new PatientTest
            {
                TestId = vm.TestId,
                TestName = vm.TestName,
                DepartmentId = vm.DepartmentId,
                //Department = vm.deptL
            };

            try
            {
                _testRepository.AddTest(pat);
                await _testRepository.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pat);
            }
        }

        // GET: TestController/Create
        public ActionResult CreateDoc()
        {
            return View(new DoctorTestViewModel());
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDoc(DoctorTestViewModel vm, IFormCollection collection)
        {
            var phy = new Physician
            {
               Id = vm.TestId,
               PhysicianName = vm.PhysicianName,
             
            };
            try
            {
                _repository.AddPhysician(phy);
                await _testRepository.SaveChangesAsync();
                return RedirectToAction("Doctor", "Home");
            }
            catch
            {
                return View(phy);
            }
        }

        // GET: TestController/Edit/5
        public ActionResult EditTest(int id)
        {
            if (id == 0)
            {
                return View(new DoctorTestViewModel());
            }
            else
            {
                var test = _testRepository.GetTest(id);
                var dept = _testRepository.GetDepartment(id);

                var res = new DoctorTestViewModel
                {
                    TestId = test.TestId,
                    TestName = test.TestName,
                    DepartmentId = test.DepartmentId
                };

                return View(res);
            }

        }

        // POST: TestController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditTest(DoctorTestViewModel vm , int id, IFormCollection collection)
        {
            var pat = new PatientTest
            {
                TestId = vm.TestId,
               TestName = vm.TestName,
               DepartmentId = vm.DepartmentId,
              
            };

            try
            {
                if (id > 0)
                {
                    _testRepository.UpdateTest(pat);
                }
                else
                {
                    _testRepository.AddTest(pat);
                }
                _testRepository.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(pat);
            }
        }

        // GET: TestController/Edit/5
        public ActionResult EditDoc(int id)
        {
            if (id == 0)
            {
                return View(new DoctorTestViewModel());
            }
            else
            {
                var phy = _repository.GetPhysician(id);

                var res = new DoctorTestViewModel
                {
                    PhysicianId = phy.Id,
                    PhysicianName = phy.PhysicianName
                    // = test.TestName,
                    //DepartmentName = dept.Department
                };

                return View(res);
            }

        }

        // POST: TestController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditDoc(DoctorTestViewModel vm, int id, IFormCollection collection)
        {
            var pat = new Physician
            {
               Id = vm.PhysicianId,
               PhysicianName = vm.PhysicianName,
              
            };

            try
            {
                if (id > 0)
                {
                    _repository.UpdatePhysician(pat);
                }
                else
                {
                    _repository.UpdatePhysician(pat);
                }
                _testRepository.SaveChangesAsync();

                return RedirectToAction("Doctor", "Home");
            }
            catch
            {
                return View(pat);
            }
        }


        // POST: TestController/Delete/5

        [HttpGet]
        public async Task<ActionResult> RemoveTest(int id, IFormCollection collection)
        {
            var test = _testRepository.GetTest(id);
             _testRepository.RemoveTest(test);
            await _testRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // POST: TestController/Delete/5

        [HttpGet]
        public async Task<ActionResult> RemoveDoc(int id, IFormCollection collection)
        {
            var phy = _repository.GetPhysician(id);
            _repository.RemovePhysician(phy);
            await _testRepository.SaveChangesAsync();

            return RedirectToAction("Doctor", "Home");
        }
    }
}
