using ApplicantSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicantSite.Models;
using System.Net;

namespace ApplicantSite.Controllers
{
    public class ApplicantController : Controller
    {
        readonly ApplicantRepository applicantsRepo;
        readonly CSharpDevDBEntities context;

        public ApplicantController():this(new CSharpDevDBEntities())
        {            
        }

        public ApplicantController(CSharpDevDBEntities context)
        {
            this.context = context;
            applicantsRepo = new ApplicantRepository(context);
        }

        // GET: Applicant
        public ActionResult Index()
        {
            var applicants = applicantsRepo.All();
            return View(applicants.Select(s => new ApplicantModel {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                ZipCode = s.ZipCode,
                Phone = s.Phone, 
                SalaryRequired = s.SalaryRequired, 
                Level_of_Expertise = s.Level_of_Expertise, 
                YearsOfExperience = s.YearsOfExperience, 
                EducationLevel = s.EducationLevel
            }).ToList());
        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Applicant/Create
        public ActionResult Create()
        {
            return View(new ApplicantModel());
        }

        // POST: Applicant/Create
        [HttpPost]
        public ActionResult Create(ApplicantModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    applicantsRepo.Add(new Applicant
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        ZipCode = model.ZipCode,
                        Phone = model.ZipCode,
                        SalaryRequired = model.SalaryRequired,
                        Level_of_Expertise = model.Level_of_Expertise,
                        YearsOfExperience = model.YearsOfExperience,
                        EducationLevel = model.EducationLevel,
                        GoodRecruit = isGoodApplicant(model)
                    });

                    context.SaveChanges();
                    TempData.AddSuccessMessage("Applicant was successfully created");
                    return RedirectToAction("Index");
                }

                TempData.AddWarningMessage("There were some validation errors on the form");
                return RedirectToAction("Create");
            }
            catch(Exception ex)
            {
                TempData.AddErrorMessage("There was an error creating applicant");
                return View();
            }
        }

        // GET: Applicant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData.AddWarningMessage("Applicant does not exist");
                return RedirectToAction("Index");
            }

            var applicant = applicantsRepo.Get((int)id);

            if (applicant == null)
            {
                TempData.AddWarningMessage("Applicant does not exist");
                return RedirectToAction("Index");
            }
            
            return View(new ApplicantModel
            {                
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                ZipCode = applicant.ZipCode,
                Phone = applicant.Phone,
                SalaryRequired = applicant.SalaryRequired,
                Level_of_Expertise = applicant.Level_of_Expertise,
                YearsOfExperience = applicant.YearsOfExperience,
                EducationLevel = applicant.EducationLevel
            });
        }

        // POST: Applicant/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, ApplicantModel model)
        {
            try
            {
                if (id == null)
                {
                    TempData.AddWarningMessage("Applicant does not exist");
                    return RedirectToAction("Index");
                }

                var applicant = applicantsRepo.Get((int)id);

                if (applicant == null)
                {
                    TempData.AddWarningMessage("Applicant does not exist");
                    return RedirectToAction("Index");
                }                    

                if (ModelState.IsValid)
                {
                    applicant.FirstName = model.FirstName;
                    applicant.LastName = model.LastName;
                    applicant.ZipCode = model.ZipCode;
                    applicant.Phone = model.Phone;
                    applicant.SalaryRequired = model.SalaryRequired;
                    applicant.Level_of_Expertise = model.Level_of_Expertise;
                    applicant.YearsOfExperience = model.YearsOfExperience;
                    applicant.EducationLevel = model.EducationLevel;

                    context.SaveChanges();
                    TempData.AddSuccessMessage("Applicant was successfully updated");

                    return RedirectToAction("Index");
                }

                TempData.AddWarningMessage("There were some validation errors on the form");
                return RedirectToAction("Edit");
            }
            catch
            {
                TempData.AddErrorMessage("There was an error updating applicant");
                return View();
            }
        }

        public ActionResult AngIndex()
        {
            return View();
        }

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool isGoodApplicant(ApplicantModel applicant)
        {
            var expertise = applicant.Level_of_Expertise;
            var salary = Convert.ToInt32(applicant.SalaryRequired);
            var years = applicant.YearsOfExperience;

            if ((expertise == ExpertiseLevel.Jr.ToString() && (salary > 55000 || years < 1)) ||
                (expertise == ExpertiseLevel.Staff.ToString() && (salary > 75000 || years < 4)) ||
                (expertise == ExpertiseLevel.Sr.ToString() && (salary > 95000 || years < 7)) ||
                (expertise == ExpertiseLevel.Supervisor.ToString() && (salary > 125000 || years < 10)))
            {
                return false;
            }            

            return true;
        }
    }
}
