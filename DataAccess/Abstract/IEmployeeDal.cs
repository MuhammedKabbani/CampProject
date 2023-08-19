using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
	public interface IEmployeeDal : IEntityRepository<Employee>
	{
		public List<EmployeeDetailDto> GetEmployeeDetails();
	}
}
