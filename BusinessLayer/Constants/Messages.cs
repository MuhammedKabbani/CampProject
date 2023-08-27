using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Constants
{
	public static class Messages
	{
		public static string EmployeeAdded = "Employee Successfully Added";
		public static string EmployeeNotAdded = "Employee Isn't Added";
		public static string NoJobId = "Invalid Job Id";
		public static string SuccessMessage = "Successfully Done.";
		public static string SimilerEmployeeName = "Employee Name Is Exsited Before";
		public static string AuthorizationDenied = "Access Denied";
		internal static string UserRegistered = "User Regestired Successfully";
		internal static string UserNotFound = "User Was Not Found";
		internal static string PasswordError = "";
		internal static string SuccessfulLogin;
		internal static string UserAlreadyExists;
		internal static string AccessTokenCreated;
	}
}
