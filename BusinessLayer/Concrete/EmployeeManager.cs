using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

		public IResult Add(Employee employee)
		{
			if(employee.job_id <= 0)
			{
				return new ErrorResult(Messages.NoJobId);
			}
			_EmployeeDal.Add(employee);

			return new SuccessResult(Messages.EmployeeAdded);
		}
		public IDataResult<Employee> GetEmployeeById(string id)
		{
			var result =  _EmployeeDal.Get(x => x.emp_id == id);
			return new SuccessDataResult<Employee>(result,Messages.SuccessMessage);
		}
		public IDataResult<List<Employee>> GetAll()
		{
			var data = _EmployeeDal.GetAll();
			return new SuccessDataResult<List<Employee>>(data);
		}
		public IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails()
		{
			var data =  _EmployeeDal.GetEmployeeDetails();
			return new SuccessDataResult<List<EmployeeDetailDto>>( data);

		}
	}
}
