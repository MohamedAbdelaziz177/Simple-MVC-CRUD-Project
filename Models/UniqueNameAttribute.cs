using DemoMvc.AppDbContext;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
	public class UniqueNameAttribute : ValidationAttribute
	{
		
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			DemoEducationaldbContext con = new DemoEducationaldbContext();
			var checkName = con.Cousres.FirstOrDefault(e => e.CrsName == value.ToString());

			if (checkName == null) {

				return ValidationResult.Success;
			}
			return new ValidationResult("Name Already Found");
		}
	}
}
