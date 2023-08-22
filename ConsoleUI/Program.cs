using BusinessLayer.Concrete;
using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
	internal class Program
	{
		static void Main(string[] args)
		{
			EmployeeManager employeeManager = new EmployeeManager(new EFEmployeeDal());

			var employees = employeeManager.GetEmployeeDetails();
			if (employees.Success)
			{
				foreach (var item in employees.Data)
				{
					Console.WriteLine(item.EmployeeName + "/" + item.JobDesc);
				}
			}
			else
			{
				Console.WriteLine(employees.Message);
			}
		
		}
	}
}