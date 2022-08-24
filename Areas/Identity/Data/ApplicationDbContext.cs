using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayRoll.TSC.PayRollModel;
using PayRoll.TSC.Models;

namespace PayRoll.TSC.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	public DbSet<NavigationMenu> NavigationMenu { get; set; }
	public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<RoleMenuPermission>().HasKey(c => new { c.RoleId, c.NavigationMenuId });

		foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.Restrict;
		}

		base.OnModelCreating(builder);
	}

	public DbSet<AccountType>? AccountType { get; set; }

	public DbSet<BankBranch>? BankBranch { get; set; }

	public DbSet<Department>? Department { get; set; }

	public DbSet<JobTitle>? JobTitle { get; set; }

	public DbSet<NavigationMenuViewModel>? NavigationMenuViewModel { get; set; }

	public DbSet<Employees>? Employees { get; set; }

	public DbSet<LeaveType>? LeaveType { get; set; }

	public DbSet<LeaveRequest>? LeaveRequest { get; set; }

	public DbSet<LeaveAllowance>? LeaveAllowance { get; set; }

	public DbSet<MaritalStatus>? MaritalStatus { get; set; }

	public DbSet<Nationality>? Nationality { get; set; }

	public DbSet<NextOfKin>? NextOfKin { get; set; }

	public DbSet<PaymentMode>? PaymentMode { get; set; }

	public DbSet<SalaryGrade>? SalaryGrade { get; set; }

	public DbSet<StateOfOrigin>? StateOfOrigin { get; set; }

	public DbSet<NHF>? NHF { get; set; }

	public DbSet<Pension>? Pension { get; set; }

	public DbSet<SalaryBreakdown>? SalaryBreakdown { get; set; }

	public DbSet<Title>? Title { get; set; }

	public DbSet<WorkData>? WorkData { get; set; }
}
