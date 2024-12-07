using DemoMvc.AppDbContext;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
	public class ExistedStdAttribute : ValidationAttribute
	{
		DemoEducationaldbContext con = new DemoEducationaldbContext();
		protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
		{

			var CheckStd = con.Students.FirstOrDefault(e => e.StudetId == (int)value);

			if (CheckStd != null)
			{

				return ValidationResult.Success;
			}
			return new ValidationResult("Not existed Student Id");

		}
	}
}
