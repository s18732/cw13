using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.DTOs.Requests
{
    public class PrzyjecieZamowienia
    {
        public DateTime dataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public List<Wyrob> wyroby { get; set; }
    }
}
