using DemoMvc.AppDbContext;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
	public class ExistedCrsAttribute : ValidationAttribute
	{
		DemoEducationaldbContext con = new DemoEducationaldbContext();
		protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
		{

			var CheckCrs = con.Cousres.FirstOrDefault(e => e.CourseId == (int)value);

			if (CheckCrs != null)
			{

				return ValidationResult.Success;
			}
			return new ValidationResult("Not existed course Id");

		}
	}
}
