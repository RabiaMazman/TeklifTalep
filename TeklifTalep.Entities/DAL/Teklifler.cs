using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifTalep.Entities.DAL
{
    public class Teklifler
    {
        [Key]
        public int Id { get; set; }
        public string Mod { get; set; }
        public string HaraketTuru { get; set; }
        public string Incoterm { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string PaketTipi { get; set; }
        public string Birim1 { get; set; }
        public string Birim2 { get; set; }
        public string ParaBirimi { get; set; }
        public decimal Fiyat { get; set; }
    }
}
