using cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Services
{
    public interface IDbService
    {
        public List<Zamowienie> GetOrders(string nazwisko);
        public List<Zamowienie> GetOrders();
        public string PrzyjmijZamowienie(DTOs.Requests.PrzyjecieZamowienia z, int idKlienta);

    }
}
