using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TravelAgency
{
    public partial class TravelAgencyDb : DbContext
    {
        public TravelAgencyDb()
            : base("name=TravelAgencyDb")
        {
        }

        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<transportationtype> transportationtypes { get; set; }
        public virtual DbSet<traveloffer> traveloffers { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<city>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.people)
                .WithRequired(e => e.city)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.traveloffers)
                .WithRequired(e => e.city)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .Property(e => e.passport)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.traveloffers)
                .WithMany(e => e.clients)
                .Map(m => m.ToTable("traveloffer_has_client", "travel_agency").MapLeftKey("idPerson").MapRightKey("idTravelOffer"));

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .HasMany(e => e.cities)
                .WithRequired(e => e.country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person>()
                .Property(e => e.pid)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .HasOptional(e => e.client)
                .WithRequired(e => e.person);

            modelBuilder.Entity<person>()
                .HasOptional(e => e.user)
                .WithRequired(e => e.person);

            modelBuilder.Entity<role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.users)
                .WithRequired(e => e.role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<transportationtype>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<transportationtype>()
                .HasMany(e => e.traveloffers)
                .WithRequired(e => e.transportationtype)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<traveloffer>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<traveloffer>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
