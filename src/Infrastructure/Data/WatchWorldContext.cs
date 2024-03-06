﻿using ApplicationCore.Constants.Entities;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infrastructure.Data
{
    public class WatchWorldContext : DbContext
	{
		public WatchWorldContext(DbContextOptions<WatchWorldContext> options) : base(options)
		{

		}
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<BasketItem> BasketItems { get; set; }
		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
