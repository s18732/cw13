using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Models
{
    public class CukierniaDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobyCukiernicze { get; set; }
        public CukierniaDbContext()
        {

        }
        public CukierniaDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klient>((builder) =>
            {
                builder.HasKey(e => e.IdKlient);
                builder.Property(e => e.IdKlient).ValueGeneratedOnAdd();

                builder.Property(e => e.Imie).HasMaxLength(50);
                builder.Property(e => e.Imie).IsRequired();

                builder.Property(e => e.Nazwisko).HasMaxLength(60);
                builder.Property(e => e.Nazwisko).IsRequired();

                builder.HasMany(e => e.Zamowienia).WithOne(e => e.Klient).HasForeignKey(e => e.IdKlient).IsRequired();
            });

            modelBuilder.Entity<Pracownik>((builder) =>
            {
                builder.HasKey(e => e.IdPracownik);
                builder.Property(e => e.IdPracownik).ValueGeneratedOnAdd();

                builder.Property(e => e.Imie).HasMaxLength(50);
                builder.Property(e => e.Imie).IsRequired();

                builder.Property(e => e.Nazwisko).HasMaxLength(60);
                builder.Property(e => e.Nazwisko).IsRequired();

                builder.HasMany(e => e.Zamowienia).WithOne(e => e.Pracownik).HasForeignKey(e => e.IdPracownik).IsRequired();
            });

            modelBuilder.Entity<WyrobCukierniczy>((builder) =>
            {
                builder.HasKey(e => e.IdWyrobuCukierniczego);
                builder.Property(e => e.IdWyrobuCukierniczego).ValueGeneratedOnAdd();

                builder.Property(e => e.Nazwa).HasMaxLength(200);
                builder.Property(e => e.Nazwa).IsRequired();

                builder.Property(e => e.CenaZaSzt).IsRequired();

                builder.Property(e => e.Typ).HasMaxLength(40);
                builder.Property(e => e.Typ).IsRequired();

                builder.HasMany(e => e.Zamowienie_WyrobCukierniczy).WithOne(e => e.WyrobCukierniczy).HasForeignKey(e => e.IdWyrobuCukierniczego).IsRequired();
            });

            modelBuilder.Entity<Zamowienie>((builder) =>
            {
                builder.HasKey(e => e.IdZamowienia);
                builder.Property(e => e.IdZamowienia).ValueGeneratedOnAdd();

                builder.Property(e => e.DataPrzyjecia).IsRequired();

                builder.Property(e => e.Uwagi).HasMaxLength(300);

                builder.HasMany(e => e.Zamowienie_WyrobyCukiernicze).WithOne(e => e.Zamowienie).HasForeignKey(e => e.IdZamowienia).IsRequired();
            });

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>((builder) =>
            {
                builder.HasKey(e => new
                {
                    e.IdWyrobuCukierniczego,
                    e.IdZamowienia
                });

                builder.Property(e => e.Ilosc).IsRequired();

                builder.Property(e => e.Uwagi).HasMaxLength(300);
            });


            var dictKlienci = new List<Klient>();
            dictKlienci.Add(new Klient { IdKlient = 1, Imie = "imie1", Nazwisko = "nazwisko1" });
            dictKlienci.Add(new Klient { IdKlient = 2, Imie = "imie2", Nazwisko = "nazwisko2" });
            dictKlienci.Add(new Klient { IdKlient = 3, Imie = "imie3", Nazwisko = "nazwisko3" });

            var dictPracownicy = new List<Pracownik>();
            dictPracownicy.Add(new Pracownik { IdPracownik = 1, Imie = "imie1", Nazwisko = "nazwisko1" });
            dictPracownicy.Add(new Pracownik { IdPracownik = 2, Imie = "imie2", Nazwisko = "nazwisko2" });
            dictPracownicy.Add(new Pracownik { IdPracownik = 3, Imie = "imie3", Nazwisko = "nazwisko3" });

            var dictWyrobyCukiernicze = new List<WyrobCukierniczy>();
            dictWyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 1, Nazwa = "nazwa1", CenaZaSzt = 1, Typ = "typ1" });
            dictWyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 2, Nazwa = "nazwa2", CenaZaSzt = 2, Typ = "typ2" });
            dictWyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 3, Nazwa = "nazwa3", CenaZaSzt = 3, Typ = "typ3" });

            var dictZamowienia = new List<Zamowienie>();
            dictZamowienia.Add(new Zamowienie { IdZamowienia = 1, DataPrzyjecia = DateTime.Now, IdKlient = 1, IdPracownik = 1 });
            dictZamowienia.Add(new Zamowienie { IdZamowienia = 2, DataPrzyjecia = DateTime.Now, IdKlient = 2, IdPracownik = 2 });
            dictZamowienia.Add(new Zamowienie { IdZamowienia = 3, DataPrzyjecia = DateTime.Now, IdKlient = 3, IdPracownik = 3 });

            var dictZamowienie_WyrobyCukiernicze = new List<Zamowienie_WyrobCukierniczy>();
            dictZamowienie_WyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { Ilosc = 1, IdWyrobuCukierniczego = 1, IdZamowienia = 1 });
            dictZamowienie_WyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { Ilosc = 2, IdWyrobuCukierniczego = 2, IdZamowienia = 2 });
            dictZamowienie_WyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { Ilosc = 3, IdWyrobuCukierniczego = 3, IdZamowienia = 3 });

            modelBuilder.Entity<Klient>().HasData(dictKlienci);
            modelBuilder.Entity<Pracownik>().HasData(dictPracownicy);
            modelBuilder.Entity<WyrobCukierniczy>().HasData(dictWyrobyCukiernicze);
            modelBuilder.Entity<Zamowienie>().HasData(dictZamowienia);
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasData(dictZamowienie_WyrobyCukiernicze);
        }
    }
}
