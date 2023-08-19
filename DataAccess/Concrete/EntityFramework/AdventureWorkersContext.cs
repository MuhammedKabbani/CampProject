using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class AdventureWorkersContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server = MUHAMMEDKB\SQLEXPRESS;Database = pubs; Trusted_Connection=true;TrustServerCertificate=True");
		}
		public DbSet<Employee> employee { get; set; }
		public DbSet<Job> Jobs { get; set; }
	}
}
