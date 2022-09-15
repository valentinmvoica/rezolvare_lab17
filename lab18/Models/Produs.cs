using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab18.Models
{
    internal class Produs
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Stoc{ get; set; }


        public int ProducatorId { get; set; }
        public Producator Producator { get; set; }


        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public Eticheta Eticheta { get; set; }
}
}
