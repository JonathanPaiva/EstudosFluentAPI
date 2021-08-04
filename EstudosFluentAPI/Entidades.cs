using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosFluentAPI
{
    class Entidades
    {

        public class Produto
        {
            public int ID { get; set; }
            public string NomeProduto { get; set; }
            public double PrecoProduto { get; set; }
        }
            
        public class Grupo
        {
            public int ID { get; set; }
            public string NomeGrupo { get; set; }
        }

        public class Fabricante
        {
            public int ID { get; set; }
            public string NomeFabricante { get; set; }
        }
    }
}
