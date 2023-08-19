using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class EmployeeManager : IEmployeeService
	{
		IEmployeeDal _EmployeeDal;

		public EmployeeManager(IEmployeeDal productDal)
		{
			_EmployeeDal = productDal;
		}

		public List<Employee> GetAll()
		{
			return _EmployeeDal.GetAll();
		}
		public List<EmployeeDetailDto> GetEmployeeDetails()
		{
			return _EmployeeDal.GetEmployeeDetails();
		}

	}
}
