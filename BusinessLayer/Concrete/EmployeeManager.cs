using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using BusinessLayer.BusinessAspects.Autofac;

namespace BusinessLayer.Concrete
{
	public class EmployeeManager : IEmployeeService
	{
		IEmployeeDal _EmployeeDal;

		public EmployeeManager(IEmployeeDal productDal)
		{
			_EmployeeDal = productDal;
		}
		[SecuredOperation("employee.add,admin")]
		[ValidationAspect(typeof(EmployeeValidator))]
		public IResult Add(Employee employee)
		{
			var result = BusinesseRules.CheckRules(
							CheckNotSimilerEmployeeNames(employee.emp_id)
							);
			if (result.Success)
			{
				_EmployeeDal.Add(employee);
				return new SuccessResult(Messages.EmployeeAdded);
			}
			return result;
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
		private IResult CheckNotSimilerEmployeeNames(string emp_name)
		{
			if(_EmployeeDal.GetAll(e=>e.fname == emp_name).Any())
			{
				return new  ErrorResult(Messages.SimilerEmployeeName);
			}
			return new SuccessResult();
		}
	}
}
