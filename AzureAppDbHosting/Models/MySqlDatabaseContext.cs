using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AzureAppDbHosting.Models;

public partial class MySqlDatabaseContext : DbContext
{
    public MySqlDatabaseContext()
    {
    }

    public MySqlDatabaseContext(DbContextOptions<MySqlDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC27BB8A23D6");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
			entity.Property(e => e.Phone).HasMaxLength(50);
			entity.Property(e => e.Notification).HasMaxLength(50);
		});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
