//
//  Author:
//    Kristijan Klepač kristijan.klepac@gmail.com
//
//  Copyright (c) 2018, www.kristijanklepac.info
//
//  All rights reserved.
//
//

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapptesy.Models;

namespace webapptesy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                .HasOne<OwnerAddress>(s => s.Address)
                .WithOne(ad => ad.Owner)
                .HasForeignKey<OwnerAddress>(ad => ad.AddressOfOwnerId);

            modelBuilder.Entity<BoatImage>()
                .HasOne<Boat>(b => b.Boat)
                .WithMany(bi => bi.BoatImages)
                .HasForeignKey(bi => bi.CurrentBoatId);

            modelBuilder.Entity<BoatCalendar>()
                .HasOne<Boat>(b => b.Boat)
                .WithMany(bc => bc.BoatCalendars)
                .HasForeignKey(bc => bc.CalendarBoatId);

            modelBuilder.Entity<ProformaInvoice>()
                .HasOne<BoatRenter>(br => br.BoatRenter)
                .WithMany(pi => pi.ProformaInvoices)
                .HasForeignKey(pi => pi.ProformaInvoiceBoatRenterId);

            modelBuilder.Entity<Invoice>()
                .HasOne<BoatRenter>(br => br.BoatRenter)
                .WithMany(i => i.Invoices)
                .HasForeignKey(i => i.InvoiceBoatRenterId);

            modelBuilder.Entity<ProformaInvoiceRows>()
                .HasOne<ProformaInvoice>(pi => pi.ProformaInvoice)
                .WithMany(pir => pir.AllProformaInvoiceRows)
                .HasForeignKey(pir => pir.CurrentProformaInvoiceId);

            modelBuilder.Entity<InvoiceRows>()
                .HasOne<Invoice>(pi => pi.Invoice)
                .WithMany(pir => pir.AllInvoiceRows)
                .HasForeignKey(pir => pir.CurrentInvoiceId);

            modelBuilder.Entity<ProformaInvoiceRows>()
                .HasOne<DayWithInterest>(dwi => dwi.DayWithInterest)
                .WithOne(pir => pir.ProformaInvoiceRows)
                .HasForeignKey<DayWithInterest>(dwi => dwi.CurrentProformaInvoiceRowId);

            modelBuilder.Entity<InvoiceRows>()
                .HasOne<DayWithNoAvailability>(dwna => dwna.DayWithNoAvailability)
                .WithOne(ir => ir.InvoiceRows)
                .HasForeignKey<DayWithNoAvailability>(dwna => dwna.CurrentInvoiceRowId);

        }

       

        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerAddress> OwnerAddresses { get; set; }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatImage> BoatImages { get; set; }
        public DbSet<BoatCalendar> BoatCalendars { get; set; }

        public DbSet<BoatRenter> BoatRenters { get; set; }
        public DbSet<ProformaInvoice> ProformaInvoices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<ProformaInvoiceRows> ProformaInvoiceRows { get; set; }
        public DbSet<InvoiceRows> InvoiceRows { get; set; }

        public DbSet<DayWithInterest> DaysWithInterest { get; set; }
        public DbSet<DayWithNoAvailability> DaysWithNoAvailability { get; set; }

        public DbSet<UserToken> UsersTokens { get; set; }

    }

}
