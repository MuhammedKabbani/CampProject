using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class EmployeeDetailDto : IDto
	{
		public string emp_id { get; set; }

		public string EmployeeName { get; set; }
		public string JobDesc { get; set; }

	}
}
