namespace DemoMvc.Models
{
	public class CourseForUser
	{
		public int CourseId { get; set; }
		public string CrsName { get; set; } = null!;

		public string? CrsCategory { get; set; }

		public int FullMark { get; set; }

		public string? inst { get; set; }

		public string? reference {  get; set; }



	}
}
