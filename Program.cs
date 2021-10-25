using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

using linq.Entities;
using linq.Entities.Enum;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Department cat0 = new Department { Id = 0, Name = "Casa" };
            Department cat1 = new Department { Id = 1, Name = "Informatica" };
            Department cat2 = new Department { Id = 2, Name = "Games" };
            Department cat3 = new Department { Id = 3, Name = "Eletrodomésticos" };
            Department cat4 = new Department { Id = 3, Name = "Brinquedos" };

            List<Product> Products = new List<Product>() {
                new Product { Id = 0, Name = "Pc Dell Optiplex-5050", Department = cat1, Prince = 3_274.47, Tier = Tier.NEW },
                new Product { Id = 1, Name = "Assadinhos Crede ;)", Department = cat2, Prince = 19.00, Tier = Tier.REFURBISHED },
                new Product { Id = 2, Name = "Mesa Triangular", Department = cat0, Prince = 7_400.00, Tier = Tier.NEW },
                new Product { Id = 3, Name = "Pendirve 32 OG Ogivas", Department = cat1, Prince = 10_089.00, Tier = Tier.USED },
                new Product { Id = 4, Name = "Boneco josias", Department = cat4, Prince = 14.20, Tier = Tier.REFURBISHED },
                new Product { Id = 5, Name = "Monitor CRT 19 Pol", Department = cat1, Prince = 16_804.00, Tier = Tier.NEW},
                new Product { Id = 6, Name = "Jogo Da velha", Department = cat2, Prince = 89.90, Tier = Tier.NEW },
                new Product { Id = 7, Name = "Armario de Teto", Department = cat0, Prince = 18_809.97, Tier = Tier.NEW },
                new Product { Id = 8, Name = "SSD 5MB 7200RPM", Department = cat1, Prince = 179.00, Tier = Tier.USED },
                new Product { Id = 9, Name = "Bola Quadrada", Department = cat4, Prince = 1_000_089.00, Tier = Tier.NEW },
                new Product { Id = 10, Name = "Panela de Arroz", Department = cat4, Prince = 79.30, Tier = Tier.NEW },
                new Product { Id = 11, Name = "Fritadeira Que Torra", Department = cat4, Prince = 99.00, Tier = Tier.REFURBISHED }
            };

            // Seleção com Where
            var selecProd = Products.Where( p => p.Department.Name == "Brinquedos" || p.Department.Name == "Games");
            
            // Seleção com Where e projeção e Objeto anônimo
            // onde Id > que 3 e < que 8
            var projection = Products.Where( p => p.Id > 3 && p.Id < 8);
            // Projeção com Objecto anônimo e Alias em Categoria
            var projectionObjAnon = Products.Where( p => p.Id > 3 && p.Id < 8).Select( s => new { s.Name, s.Prince, s.Id, Cat = s.Department.Name });
            
            // Agregation
            var min = Products.Min( p => p.Prince); 
            var max = Products.Max( p => p.Prince);
            var avg = Products.Average( p => p.Prince);

            // Ordenando por preço caso aja mais que um igual ordene por nome
            var orByPrince = Products.Where( p => p.Tier == Tier.NEW).OrderBy( pp => pp.Prince).ThenBy( pn => pn.Name);
            
            // Console.WriteLine(String.Join(" ", selecProd));

            Console.WriteLine(String.Join(" ", projection));
            Console.WriteLine(String.Join(" ", projectionObjAnon));

            Console.WriteLine(min.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(max.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(avg.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine(String.Join("",orByPrince));
        }
    }
}
