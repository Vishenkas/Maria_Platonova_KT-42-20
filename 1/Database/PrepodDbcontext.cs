using _1.Database.Configurations;
using _1.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace _1.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Kafedra> Kafedra { get; set; }

        public DbSet<Stepen> Stepen { get; set; }
        public DbSet<Prepod> Prepod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
            modelBuilder.ApplyConfiguration(new StepenConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}
