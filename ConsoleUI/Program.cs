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

			foreach (var item in employees)
			{
				Console.WriteLine(item.EmployeeName + "/" + item.JobDesc);
			}
		
		}
	}
}