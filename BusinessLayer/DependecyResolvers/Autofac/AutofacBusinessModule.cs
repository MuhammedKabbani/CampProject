using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
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
			builder.RegisterType<EFUserDal>().As<IUserDal>().SingleInstance();
			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
			builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
