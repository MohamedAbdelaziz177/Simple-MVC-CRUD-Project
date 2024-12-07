using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models;

public partial class Courseentrollment
{
    [Required]
    [Display(Name = "Enter Crs ID")]
    [ExistedCrs(ErrorMessage = "Not existed in Server")]
    public int CousreCourseId { get; set; }

	[Required]
	[Display(Name = "Enter Std ID")]
	[Remote("ValidateStdID", "Enrollment", ErrorMessage = "Enter Existed ID")]
	[ExistedStd(ErrorMessage = "Not existed in Server")]

	public int StudentStudetId { get; set; }

    [Range(0, 100, ErrorMessage = "Enter Valid degree")]
    [Display(Name = "Enter Degree")]
    public int? Degree { get; set; }

    public virtual Cousre CousreCourse { get; set; } = null!;

    public virtual Student StudentStudet { get; set; } = null!;
}
