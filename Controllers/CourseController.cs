using Microsoft.AspNetCore.Mvc;
using DemoMvc.Models;
using DemoMvc.AppDbContext;

namespace DemoMvc.Controllers
{
	public class CourseController : Controller
	{

		DemoEducationaldbContext con = new DemoEducationaldbContext();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ShowCourseHome()
		{
			return View("Home");
		}


		[HttpGet]
		public IActionResult AddNewCourse()
		{
			ViewData["instructors"] =  con.Instructors.Select(x => new {x.InstructorId, x.InstName }).ToList();
			ViewData["refs"] = con.References.Select(x => new { x.RefId , x.RefName }).ToList();

			ViewData["CurrID"] = con.Cousres.Max(x => x.CourseId) + 1;

			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public IActionResult SaveNewCourse(Cousre crs)
		{

			ViewData["instructors"] = con.Instructors.ToList();
			ViewData["refs"] = con.References.ToList();

			
			Reference Ref = con.References.FirstOrDefault(x => x.RefId == crs.ReferenceRefId);
			
			Instructor instructor = con.Instructors.FirstOrDefault(x => x.InstructorId == crs.InstructorId);

			crs.Instructor = instructor;
			crs.ReferenceRef = Ref;



			ModelState.Remove("Instructor");  // Ignore errors for the Instructor navigation property
			ModelState.Remove("ReferenceRef");


			if (ModelState.IsValid)
			{

				try
				{
					con.Cousres.Add(crs);
					con.SaveChanges();

					return RedirectToAction(nameof(ShowAllCourses));
				}
				catch (Exception ex) {

					return RedirectToAction(nameof (AddNewCourse));
				}
			}

			

			return View("AddNewCourse");
		}

		[HttpGet]
		public IActionResult EditCourse(int id)
		{

			var course = con.Cousres.FirstOrDefault(x => x.CourseId == id);

			ViewData["instructors"] = con.Instructors.Select(x => new { x.InstructorId, x.InstName }).ToList();
			ViewData["refs"] = con.References.Select(x => new { x.RefId, x.RefName }).ToList();

			return View(course);
		}

		[HttpPost]
		public IActionResult SaveEdit(CourseEdited newCourse)
		{
			Reference Ref = con.References.FirstOrDefault(x => x.RefId == newCourse.ReferenceRefId);

			Instructor instructor = con.Instructors.FirstOrDefault(x => x.InstructorId == newCourse.InstructorId);

			newCourse.Instructor = instructor;
			newCourse.ReferenceRef = Ref;


			ModelState.Remove("Instructor");  // Ignore errors for the Instructor navigation property
			ModelState.Remove("ReferenceRef");


			var oldCourse = con.Cousres.FirstOrDefault(x => x.CourseId == newCourse.CourseId);

			

			if (ModelState.IsValid)
			{

				try
				{
					
					oldCourse.CourseId = newCourse.CourseId;
					oldCourse.Hours = newCourse.Hours;
					oldCourse.FullMark = newCourse.FullMark;
					oldCourse.CrsCategory = newCourse.CrsCategory;
					oldCourse.CrsName = newCourse.CrsName;
					oldCourse.InstructorId = newCourse.InstructorId;
					oldCourse.ReferenceRefId = newCourse.ReferenceRefId;
					oldCourse.Instructor = newCourse.Instructor;
					oldCourse.ReferenceRef = newCourse.ReferenceRef;
					
					con.SaveChanges();

					return RedirectToAction(nameof (ShowAllCourses));
					
				}
				catch (Exception ex)
				{
					return RedirectToAction("EditCourse",  new { id = oldCourse.CourseId });
				}
			}

			return RedirectToAction("EditCourse", new { id = oldCourse.CourseId });
		}


		//}

		public IActionResult RemoveCourse(int id) 
		{ 
			var course = con.Cousres.FirstOrDefault(con => con.CourseId == id);
			con.Cousres.Remove(course);
			con.SaveChanges();

			return RedirectToAction(nameof(ShowAllCourses));
		}

		public IActionResult ShowAllCourses()
		{
			var courses = new List<CourseForUser>();

			 courses = (
				         from item1 in con.Cousres
					     join item2 in con.Instructors
					     on item1.InstructorId equals item2.InstructorId
					     join item3 in con.References
					     on item1.ReferenceRefId equals item3.RefId
					     select 
					     new CourseForUser()
					     { 
						   CourseId = item1.CourseId,
					       CrsName = item1.CrsName,
					       FullMark = item1.FullMark,
					       CrsCategory = item1.CrsCategory,
					       inst = item2.InstName,
					       reference = item3.RefName
					     }
					  )
					  .ToList();

			ViewBag.courses = courses;

			return View(courses);
		}

		[HttpGet]
		public IActionResult ShowCourseByName(){ 
			ViewData["IdLst"] = con.Cousres.ToList();
			return View();
		}

		[HttpPost]
		public IActionResult GetCourseByName(int CourseId)
		{
			//ViewData["IdLst"] = con.Cousres.ToList();

			var courses = (
						from item1 in con.Cousres
						join item2 in con.Instructors
						on item1.InstructorId equals item2.InstructorId
						join item3 in con.References
						on item1.ReferenceRefId equals item3.RefId
						select
						new CourseForUser()
						{
							CourseId = item1.CourseId,
							CrsName = item1.CrsName,
							FullMark = item1.FullMark,
							CrsCategory = item1.CrsCategory,
							inst = item2.InstName,
							reference = item3.RefName
						}
					 );

			var course = courses.Where(x => x.CourseId == CourseId).ToList();

			//List<CourseForUser> courses = new List<CourseForUser> { };



			return View("ShowAllCourses", course.ToList());
		}

	}
}
