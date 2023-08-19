using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFEmployeeDal : EFEntityRepositoryBase<Employee, AdventureWorkersContext>, IEmployeeDal
	{
		public List<EmployeeDetailDto> GetEmployeeDetails()
		{
			using (AdventureWorkersContext context = new AdventureWorkersContext())
			{
				var result = (from e in context.employee
							 join j in context.Jobs on
							 e.job_id equals j.job_id
							 select new EmployeeDetailDto() {
								 EmployeeName = e.fname, emp_id = e.emp_id,
								 JobDesc = j.job_desc 
							 }).ToList();
				return result;
			}
		}
	}
}
