using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
	public class Employee : IEntity
	{
		[Key]
		public string emp_id { get; set; }
		public short job_id { get; set; }
		public string fname { get; set; }
	}
}
