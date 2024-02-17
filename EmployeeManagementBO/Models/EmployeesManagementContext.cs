using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementBO.Models
{
    public partial class EmployeesManagementContext : DbContext
    {
        public EmployeesManagementContext()
        {
        }

        public EmployeesManagementContext(DbContextOptions<EmployeesManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobHistory> JobHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:EmployeeManagement"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_ACCOUNT_USERNAME");

                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DeleteFlag).HasColumnName("DELETE_FLAG");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .HasMaxLength(80)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(80)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(80)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Role)
                    .HasMaxLength(4)
                    .HasColumnName("ROLE");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");

                entity.HasOne(d => d.Address)
                    .WithOne(a => a.Account)
                    .HasForeignKey<Account>(d => d.AddressId)
                    .HasConstraintName("FK_ACCOUNT_ADDRESS");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("CITY");

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .HasColumnName("PROVINCE");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("STREET");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.Ward)
                    .HasMaxLength(50)
                    .HasColumnName("WARD");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasColumnName("DEPARTMENT_NAME");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.HiredDate)
                    .HasColumnType("date")
                    .HasColumnName("HIRED_DATE");

                entity.Property(e => e.JobId).HasColumnName("JOB_ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_DEPARTMENT");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_JOB");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_ACCOUNT");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("JOB");

                entity.Property(e => e.JobId).HasColumnName("JOB_ID");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.Salary).HasColumnName("SALARY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.ToTable("JOB_HISTORY");

                entity.Property(e => e.JobHistoryId).HasColumnName("JOB_HISTORY_ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EndedDate)
                    .HasColumnType("date")
                    .HasColumnName("ENDED_DATE");

                entity.Property(e => e.JobId).HasColumnName("JOB_ID");

                entity.Property(e => e.StartedDate)
                    .HasColumnType("date")
                    .HasColumnName("STARTED_DATE");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_JOB_HISTORY_DEPARTMENT");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_JOB_HISTORY_EMPLOYEE");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_JOB_HISTORY_JOB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
