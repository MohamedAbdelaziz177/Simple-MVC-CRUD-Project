using DemoMvc.AppDbContext;
using DemoMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
	public class StudentController : Controller
	{

		// Establishing the connection with database
		DemoEducationaldbContext con = new DemoEducationaldbContext();

		public IActionResult Index()
		{
			return View();
		}

		// Getting The whole list of students
		public IActionResult GetAllStudents()
		{
			List<Student> stds = con.Students.OrderBy(x => x.StudetId).ToList();

			return View("AllStudents",stds);
		}


		// Presenting Blank list to insert new students
		[HttpGet]
		public IActionResult showRegForm()
		{
			 
			return View("MainForm", new Student() { });
		}

		// Recieve the data from the client and save it

		[HttpPost]
		//[AutoValidateAntiforgeryToken]

		
		public IActionResult SaveNewUser(Student st)
		{
			var check = con.Students.FirstOrDefault(x => x.StudetId == st.StudetId);
			if (check == null && st.StdName != null)
			{

			
				con.Students.Add(st);
				con.SaveChanges();

				return GetAllStudents();
			}
			else
			return RedirectToAction("showRegForm");


		}


		// Edit already added student in database

		[HttpGet]
		public IActionResult EditStudent(int id)
		{
			Student student = con.Students.FirstOrDefault(x => x.StudetId == id);

			if(student != null)
			return View("StudentModification", student);

			return showRegForm();
		}

		[HttpPost]

	//	[AutoValidateAntiforgeryToken]
		public IActionResult SaveChanges(Student st)
		{
			var isExisted = con.Students.FirstOrDefault(x => x.StudetId == st.StudetId);                          
			if (isExisted == null)
			{
				return RedirectToAction("showRegForm");
			}

			else { 
				con.Students.Remove(isExisted);
				con.Students.Add(st);
				con.SaveChanges();

				return RedirectToAction("GetAllStudents");
			}
		}

		// Delete Student
		public IActionResult DeleteStudent(int id)
		{
			Student student = con.Students.FirstOrDefault(x => x.StudetId == id);
			con.Students.Remove(student);

			con.SaveChanges();
			return RedirectToAction("GetAllStudents");

		}

		// Routhing to the View of getting student by id

		[HttpGet]
		public IActionResult GetStudentById(int id) {

			return View("StudentById");
			
		}

		// recieve the id and show the student

		[HttpPost]
		//[AutoValidateAntiforgeryToken]

		public IActionResult GetStudentHimself(int id)
		{
			
			
			var student = con.Students.FirstOrDefault(x => x.StudetId == id);
			List<Student>students = new List<Student>();
			students.Add(student);

			if (student != null) return View("AllStudents", students);

			else return View("Home");
			
		}


		public IActionResult ShowStudentHome() { return View("Home"); }


		

	}
}
