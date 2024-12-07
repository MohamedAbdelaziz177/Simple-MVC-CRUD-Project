using Microsoft.AspNetCore.Mvc;
using DemoMvc.AppDbContext;
using DemoMvc.Models;

namespace DemoMvc.Controllers
{
	public class EnrollmentController : Controller
	{
		private DemoEducationaldbContext con = new DemoEducationaldbContext();
		public IActionResult Index()
		{
			var enrolls = con.Courseentrollments.ToList();
			return View(enrolls);
		}

		[HttpGet]
		public IActionResult EnrollForCourse()
		{
			return PartialView("EnrollmentPartial");
		}

		[HttpPost]
		public IActionResult SaveEnroll(Courseentrollment Std_crs) {

			ModelState.Remove("CousreCourse");
			ModelState.Remove("StudentStudet");

			if (!ModelState.IsValid) {
				//return View("~/Views/Home/Index.cshtml");
				return View("EnrollmentPartial");
			}


			con.Courseentrollments.Add(Std_crs);
			con.SaveChanges();

			return RedirectToAction("Index");

			


		}

		public JsonResult ValidateStdID(int StudentStudetId)
		{
			var std = con.Students.FirstOrDefault(x => x.StudetId == StudentStudetId);

            if (std != null)
            {
				return Json(true);
            }

			return Json(false);
        }

		public JsonResult ValidateCrsID(int CrsId) {

			var crs = con.Cousres.FirstOrDefault(x => x.CourseId == CrsId);

			if (crs != null) { 
				return Json(true);
			}

			return Json(false);
		}
	}
}
