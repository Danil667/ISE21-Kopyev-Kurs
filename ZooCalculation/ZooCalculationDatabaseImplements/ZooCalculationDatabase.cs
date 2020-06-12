using Microsoft.EntityFrameworkCore;
using System;
using ZooCalculationDatabaseImplements.Models;

namespace ZooCalculationDatabaseImplements
{
	public class ZooCalculationDatabase : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
			}
			base.OnConfiguring(optionsBuilder);
		}
		public virtual DbSet<Route> Routes { set; get; }
		public virtual DbSet<Excursion> Excursions { set; get; }
		public virtual DbSet<RouteForExcursion> RouteForExcursions { set; get; }
		public virtual DbSet<Client> Clients { set; get; }
		public virtual DbSet<Order> Orders { set; get; }
	}
}
