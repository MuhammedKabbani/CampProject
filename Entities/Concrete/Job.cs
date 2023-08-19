using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
	public class Job : IEntity
	{
		[Key]
		public int job_id { get; set; }
		public string job_desc { get; set; }
	}
}
