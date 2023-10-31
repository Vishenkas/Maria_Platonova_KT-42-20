using _1.Database.Configurations;
using _1.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace _1.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        DbSet<Kafedra> Kafedra { get; set; }
        DbSet<Prepod> Prepod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}
