using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurante.ApplicationCore.Entity
{
    public class restaurante
    {
        public restaurante()
        {

        }
        public int id { get; set; }
        public string nome { get; set; }

        public List<prato> pratos { get; set; }
    }
}
