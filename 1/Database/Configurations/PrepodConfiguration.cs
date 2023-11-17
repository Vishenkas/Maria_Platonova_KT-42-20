using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.Database.Helpers;
using _1.Models;

namespace _1.Database.Configurations
{
    public class PrepodConfiguration : IEntityTypeConfiguration<Prepod>
    {
        private const string TableName = "cd_prepod";

        public void Configure(EntityTypeBuilder<Prepod> builder)
        {
            builder
                .HasKey(p => p.PrepodId)
                .HasName($"pk_{TableName}_prepod_id");

            builder.Property(p => p.PrepodId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PrepodId)
                .HasColumnName("prepod_id")
                .HasComment("Индетификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_prepod_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_prepod_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_prepod_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.KafedraId)
                .HasColumnName("kafedra_id")
                .HasComment("Индетификатор кафедры")
                .HasColumnType(ColumnType.Int);


            builder.ToTable(TableName)
                .HasOne(p => p.Kafedra)
                .WithMany()
                .HasForeignKey(p => p.KafedraId)
                .HasConstraintName("fk_c_kafedra_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.StepenId)
                .HasColumnName("stepen_id")
                .HasComment("Индетификатор степени")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
                .HasOne(p => p.Stepen)
                .WithMany()
                .HasForeignKey(p => p.StepenId)
                .HasConstraintName("fk_c_stepen_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.KafedraId, $"idx_{TableName}_fk_c_kafedra_id");

            builder.ToTable(TableName)
                .HasIndex(p => p.StepenId, $"idx_{TableName}_fk_c_stepen_id");

            builder.Navigation(p => p.Kafedra)
                .AutoInclude();

            builder.Navigation(p => p.Stepen)
                .AutoInclude();
        }

    }
}
