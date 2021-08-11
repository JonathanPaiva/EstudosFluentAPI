using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosFluentAPI
{
    public class Entidades
    {

        public class Produto
        {
            public int CodigoProduto { get; set; }
            public string Referencia { get; set; }
            public string NomeProduto { get; set; }
            public double PrecoProduto { get; set; }
            public DateTime DataCriacao { get; set; }
            public DateTime DataAtualizado { get; set; }
            public bool Desativado { get; set; }
        }
            
        public class Grupo
        {
            public int ID { get; set; }
            public string NomeGrupo { get; set; }
        }

        public class Cliente
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }

        
        }

        public class Fabricante
        {
            public int ID { get; set; }
            public string NomeFabricante { get; set; }
        }
    }
}
