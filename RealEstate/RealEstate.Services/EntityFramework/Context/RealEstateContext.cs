using Microsoft.EntityFrameworkCore;
using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.EntityFramework.Context
{
	public class RealEstateContext : DbContext
	{
		public RealEstateContext(DbContextOptions<RealEstateContext> opt) : base(opt)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=DESKTOP-4FAV1LC\\SQLEXPRESS; Database=RealEstateDb;TrustServerCertificate=True; Trusted_connection=true;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.Entity<FavoriteAdvert>()
				.HasOne(fa => fa.User)          // User ile ilişki
				.WithMany(u => u.FavoriteAdverts) // User'ın birden fazla favori ilanı olabilir
				.HasForeignKey(fa => fa.UserId)  // Foreign key UserId
				.OnDelete(DeleteBehavior.Restrict);  // Cascade delete işlemi olmasın

			
			modelBuilder.Entity<FavoriteAdvert>()
				.HasOne(fa => fa.Advert)          // Advert ile ilişki
				.WithMany(a => a.FavoriteAdverts) // Bir Advert'in birden fazla favorisi olabilir
				.HasForeignKey(fa => fa.AdvertId) // Foreign key AdvertId
				.OnDelete(DeleteBehavior.Restrict); // Cascade delete işlemi olmasın
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Advert> Adverts { get; set; }
		public DbSet<FavoriteAdvert> FavoriteAdverts { get; set; }
	}
}
