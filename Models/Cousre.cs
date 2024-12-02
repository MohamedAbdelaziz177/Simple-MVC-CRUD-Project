using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc.Models;

public partial class Cousre
{

	[Display(Name = "Enter Course's ID")]

	public int CourseId { get; set; } = 1;

	[Display(Name = "Enter Course's Name")]
	[Required(ErrorMessage = "Required!!")]
	[DataType(DataType.Text)]
	[StringLength(100, MinimumLength = 4, ErrorMessage = "Between 4 Chars to 100 chars !!")]
	[UniqueName(ErrorMessage = "Name Already found")]
	public string CrsName { get; set; } = null!;


	[Display(Name = "Enter Course's Category")]

	public string? CrsCategory { get; set; }

	[Display(Name = "Enter Course's Num of Hrs")]

	[Range(20, 60, ErrorMessage = "PLZ enter value between 20 & 60")]

	public decimal? Hours { get; set; }

	[Display(Name = "Enter Course's Full Mark")]

	[Range(20, 100, ErrorMessage = "PLZ enter value between 20 & 100")]
	public int FullMark { get; set; }

	[Display(Name = "Who is the instructor")]

	public int? InstructorId { get; set; }

	[Display(Name = "Which Refrence validates the course")]

	public int? ReferenceRefId { get; set; }

    public virtual ICollection<Courseentrollment> Courseentrollments { get; set; } = new List<Courseentrollment>();

	//[BindNever]
   public virtual Instructor Instructor { get; set; } = new Instructor() { InstName = ""};


	//[BindNever]
	public virtual Reference  ReferenceRef { get; set; } = new Reference() { RefName = ""};
}
