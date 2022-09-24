using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab18.Models
{
    public class ProdusElectronic : Produs
    {
        public Voltage Voltage { get; set; } = Voltage._220;
        public int Wattage { get; set; }
    }
    public enum Voltage
    {
        _220,
        _110
    }
}
