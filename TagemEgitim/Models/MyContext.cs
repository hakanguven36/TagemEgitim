using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.Models
{
	public class MyContext : DbContext
	{
		public MyContext(DbContextOptions<MyContext> options) : base(options)
		{
		}

		public DbSet<Kullar> Kullar { get; set; }
		public DbSet<Kişi> Kişiler { get; set; }
		public DbSet<Ünvan> Ünvanlar { get; set; }
		public DbSet<Ülke> Ülkeler { get; set; }
		public DbSet<Kurs> Kurslar { get; set; }
		public DbSet<Obscure> Obscures { get; set; }
		public DbSet<KişiKurs> kişikurs { get; set; }
	}
}
