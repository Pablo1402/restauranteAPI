using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurante.ApplicationCore.Entity
{
    public class prato
    {
        public prato()
        {

        }

        public int id { get; set; }
        public int restaurante_id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }

        public restaurante restaurante { get; set; }
    }
}
