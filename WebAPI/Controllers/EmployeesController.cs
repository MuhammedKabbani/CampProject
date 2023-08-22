using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		IEmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _employeeService.GetAll();
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(string id)
		{
			var result = _employeeService.GetEmployeeById(id);
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}
		[HttpPost("add")]
		public IActionResult Add(Employee employee)
		{
			var result = _employeeService.Add(employee);
			if (result.Success)
			{
				return Ok();
			}
			return BadRequest(result.Message);
		}
	}
}
