namespace Mortgage.Domain.Infrastructure
{
    using System;
    using System.IO;
    using System.Linq;
    using Common;
    using Domain.Utilities.Json;
    using Lenders;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using Newtonsoft.Json;
    using Seed;

    public class MortgageDbContext : DbContext
    {
        public MortgageDbContext()
        {
            GuidGenerator = SequentialGuidGenerator.Instance;
        }

        public DbSet<Country> Countries { get; set; }

        /// <summary>
        ///     Reference to GUID generator.
        /// </summary>
        public IGuidGenerator GuidGenerator { get; set; }

        public DbSet<Lender> Lenders { get; set; }

        private static Country[] GetCountries()
        {
            return JsonConvert.DeserializeObject<Country[]>(SeedHelper.GetCountries(),new CountryConverter());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=App_Data\\mortgage.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Lender>(e =>
                {            
                    e.HasKey(p => p.Id);
                    e.Property(p => p.Id).ValueGeneratedOnAdd();

                    e.Ignore(p => p.DomainEvents);
                    e.Ignore(p => p.AllowedCountries);
                    e.Ignore(p => p.SanctionedCountries);

                    e.Property(p => p.Name).IsRequired();

                    e.HasMany(p => p.Countries)
                        .WithOne(c => c.Lender)
                        .HasForeignKey(c => c.LenderId);

                    e.OwnsOne(p => p.NewProperty);
                    e.OwnsOne(p => p.PrimaryContactInformation);
                    e.OwnsOne(p => p.UsedProperty);
                    e.OwnsOne(p => p.SecondaryContactInformation);
                    e.OwnsOne(p => p.SelfEmployment);

                    e.Property(p => p.Citizenship).HasConversion(new EnumToStringConverter<Citizenship>());

                    var meta = e.Metadata;

                    meta.FindNavigation(nameof(Lender.Countries))
                        .SetField("_countries");
                });

            modelBuilder
                .Entity<LenderCountry>(e =>
                {
                    e.HasKey(p => p.Id);
                    e.Property(p => p.Id).ValueGeneratedOnAdd();

                    e.Property(p => p.Name).IsRequired();
                });

            modelBuilder
                .Entity<Country>(e =>
                {
                    e.HasKey(p => p.Id);
                    e.Property(p => p.Id).ValueGeneratedNever();

                    e.Property(p => p.Code).IsRequired();

                    e.HasData(GetCountries());
                });
        }

        public override int SaveChanges()
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in ChangeTracker.Entries().ToList())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is IEntity<Guid> entity && entity.Id == Guid.Empty)
                    {
                        entity.Id = GuidGenerator.Create();
                    }
                }

                TriggerDomainEvents(entry.Entity);
            }

            return base.SaveChanges();
        }

        protected virtual void TriggerDomainEvents(object entityAsObj)
        {
            IGeneratesDomainEvents generatesDomainEventsEntity = entityAsObj as IGeneratesDomainEvents;

            if (generatesDomainEventsEntity?.DomainEvents == null || !generatesDomainEventsEntity.DomainEvents.Any())
            {
                return;
            }

            System.Collections.Generic.List<IDomainEvent> domainEvents = generatesDomainEventsEntity.DomainEvents.ToList();
            generatesDomainEventsEntity.DomainEvents.Clear();

            foreach (IDomainEvent domainEvent in domainEvents)
            {
                DomainEvents.Publish(domainEvent);
            }
        }
    }
}