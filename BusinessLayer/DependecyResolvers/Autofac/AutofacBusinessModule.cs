using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependecyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
			builder.RegisterType<EFEmployeeDal>().As<IEmployeeDal>().SingleInstance();
		}
	}
}
