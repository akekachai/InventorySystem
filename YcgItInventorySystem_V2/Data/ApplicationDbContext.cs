using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Models;

namespace YcgItInventorySystem_V2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AppModule> AppModule { get; set; }
        public virtual DbSet<AppMenu> AppMenu { get; set; }
        public virtual DbSet<AppRole> AppRole { get; set; }
        public virtual DbSet<AppRoleMenu> AppRoleMenu { get; set; }
        public virtual DbSet<AppRoleEmployee> AppRoleEmployee { get; set; }
        public DbSet<EmpMstEmployee> EmpMstEmployee { get; set; }

        public virtual DbSet<SP_EmpMstEmployeeActive> SP_EmpMstEmployeeActive { get; set; }
        public virtual DbSet<EmpMstCompany> EmpMstCompany { get; set; }
    
        public virtual DbSet<EmpMstDepartment> EmpMstDepartment { get; set; }
        public virtual DbSet<EmpNamePrefix> EmpNamePrefix { get; set; }

        public virtual DbSet<EmpMstPosition> EmpMstPosition { get; set; }
        public virtual DbSet<EmpMstSection> EmpMstSection { get; set; }
        public virtual DbSet<EmpMstLevel> EmpMstLevel { get; set; }
        public virtual DbSet<EmpMstLocation> EmpMstLocation { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRoleEmployee>().HasKey(table => new {
                table.AppId,
                table.Username
            });

            builder.Entity<AppRoleMenu>().HasKey(Col => new {
                Col.AppRoleId,
                Col.AppMenuId
            });

            builder.Entity<EmpMstDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("EmpMstDepartment");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentDescription).HasMaxLength(200);

                entity.Property(e => e.DepartmentText).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

          
        }
    }
}
