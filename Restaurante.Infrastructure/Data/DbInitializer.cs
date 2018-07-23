using Restaurante.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initializer(RestauranteContext context)
        {
            if (context.restaurantes.Any())
                return;

            var restaurantes = new restaurante[]
            {
                new restaurante
                {
                    id = 1,
                    nome = "Primeiro Restaurante SA."
                }
            };
            var pratos = new prato[]
            {
                new prato
                {
                    id = 1,
                    nome = "Galinhada",
                    preco = 10,
                    restaurante_id = 1
                },
                new prato
                {
                    id= 2,
                    nome= "Feijoada",
                    preco= 20.20M,
                    restaurante_id = 1
                }
            }; 
            context.AddRange(restaurantes);
            context.AddRange(pratos);
            context.SaveChanges();
        }
    }
}
