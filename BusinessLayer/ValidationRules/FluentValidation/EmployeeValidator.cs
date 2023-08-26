using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
	public class EmployeeValidator : AbstractValidator<Employee>
	{
		public EmployeeValidator()
		{
			RuleFor(e => e.emp_id).NotEmpty();
			RuleFor(e => e.fname).MinimumLength(2);
			RuleFor(e => e.emp_id).NotEmpty().When(e => e.job_id == 1);
			RuleFor(e => e.job_id).Must(BiggerThanZero);
		}

		private bool BiggerThanZero(short arg)
		{
			return arg > 0;
		}
	}
}
