using cw13.DTOs.Requests;
using cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Services
{
    public class EfDbService : IDbService
    {
        public CukierniaDbContext _context { get; set; }
        public EfDbService(CukierniaDbContext context)
        {
            _context = context;
        }

        public List<Zamowienie> GetOrders(string nazwisko)
        {
            var list = _context.Zamowienia.Where(e => e.Klient.Nazwisko == nazwisko).ToList();
            return list;
        }

        public List<Zamowienie> GetOrders()
        {
            var list = _context.Zamowienia.ToList();
            return list;
        }

        public string PrzyjmijZamowienie(DTOs.Requests.PrzyjecieZamowienia z, int idKlienta)
        {
            foreach(Wyrob w in z.wyroby)
            {
                if(!(_context.WyrobyCukiernicze.Any(wyrob => wyrob.Nazwa == w.wyrob)))
                {
                    return "Nie ma takiego wyrobu";
                }
            }
            var zam = new Zamowienie { IdPracownik = 1 ,DataPrzyjecia = z.dataPrzyjecia, IdKlient = idKlienta, Uwagi = z.Uwagi, Zamowienie_WyrobyCukiernicze = new List<Zamowienie_WyrobCukierniczy>() } ;
            foreach (Wyrob w in z.wyroby)
            {
                int id = _context.WyrobyCukiernicze.FirstOrDefault(wyrob => wyrob.Nazwa == w.wyrob).IdWyrobuCukierniczego;
                zam.Zamowienie_WyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = id, Uwagi = w.uwagi, Ilosc = w.Ilosc});
            }

            _context.Add(zam);
            _context.SaveChanges();

            return "Zamowienie zostalo przyjete";

        }
    }
}
