using Microsoft.EntityFrameworkCore;
using System;
using Data.Models;

namespace Data
{
	public class Database : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-8MB9FIAG\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;MultipleActiveResultSets=True;");
			}
			base.OnConfiguring(optionsBuilder);
		}
		public virtual DbSet<Models.Data> Datas { set; get; }
	}
}
