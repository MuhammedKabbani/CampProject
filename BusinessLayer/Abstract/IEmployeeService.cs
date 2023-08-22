using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IEmployeeService
	{
		IDataResult<List<Employee>> GetAll();

		IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails();
		IResult Add(Employee employee);
		IDataResult<Employee> GetEmployeeById(string id);
	}
}
