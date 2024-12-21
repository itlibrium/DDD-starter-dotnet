using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.Contacts.Companies;
using MyCompany.ECommerce.Contacts.Groups;
using MyCompany.ECommerce.Contacts.Tags;
using P3Model.Annotations.Technology;

namespace MyCompany.ECommerce.Contacts.Database;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
[Database("Contacts", ClusterName = "Postgres")]
public class ContactsDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureContact(modelBuilder);
        ConfigureContactGroup(modelBuilder);
        ConfigureContactTag(modelBuilder);
        ConfigureGroupTag(modelBuilder);
    }

    private static void ConfigureContact(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .OwnsOne(company => company.Address);
        modelBuilder.Entity<Company>()
            .OwnsMany(company => company.Phones, phone =>
            {
                phone.WithOwner().HasForeignKey(nameof(Phone.CompanyId));
                phone.HasKey(nameof(Phone.Number));
            });
    }

    private static void ConfigureContactGroup(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyGroup>()
            .HasKey(companyGroup => new {companyGroup.CompanyId, companyGroup.GroupId});
        modelBuilder.Entity<CompanyGroup>()
            .HasOne(companyGroup => companyGroup.Company)
            .WithMany(company => company.Groups)
            .HasForeignKey(companyGroup => companyGroup.CompanyId);
        modelBuilder.Entity<CompanyGroup>()
            .HasOne(companyGroup => companyGroup.Group)
            .WithMany(tag => tag.Companies)
            .HasForeignKey(companyTag => companyTag.CompanyId);
    }

    private static void ConfigureContactTag(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyTag>()
            .HasKey(companyTag => new {companyTag.CompanyId, companyTag.TagId});
        modelBuilder.Entity<CompanyTag>()
            .HasOne(companyTag => companyTag.Company)
            .WithMany(company => company.Tags)
            .HasForeignKey(companyTag => companyTag.CompanyId);
        modelBuilder.Entity<CompanyTag>()
            .HasOne(companyTag => companyTag.Tag)
            .WithMany(tag => tag.Companies)
            .HasForeignKey(companyTag => companyTag.TagId);
    }

    private static void ConfigureGroupTag(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupTag>()
            .HasKey(groupTag => new {groupTag.GroupId, groupTag.TagId});
        modelBuilder.Entity<GroupTag>()
            .HasOne(groupTag => groupTag.Group)
            .WithMany(group => group.Tags)
            .HasForeignKey(groupTag => groupTag.GroupId);
        modelBuilder.Entity<GroupTag>()
            .HasOne(groupTag => groupTag.Tag)
            .WithMany(tag => tag.Groups)
            .HasForeignKey(groupTag => groupTag.TagId);
    }
}