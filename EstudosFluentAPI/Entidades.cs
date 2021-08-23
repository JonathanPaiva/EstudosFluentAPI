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
            public ICollection<ClienteEndereco> ClienteEndereco { get; set; }
        }

        public class ClienteEndereco
        {
            public int ID { get; set; }
            public string EndCompleto { get; set; }
            public int ClienteID { get; set; }
            public Cliente Cliente{ get; set; }
        }

        public class Fabricante
        {
            public int ID { get; set; }
            public string NomeFabricante { get; set; }
        }

        public class Aluno
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public AlunoEndereco Endereco { get; set; }
        }

        public class AlunoEndereco
        {
            public int IDEndereco { get; set; }
            public string EndCompleto { get; set; }
            public int AlunoID { get; set; }
            public Aluno Aluno { get; set; }
        }
        public class CadastroAluno
        {
            public int CodAluno { get; set; }
            public string Nome { get; set; }
            public ICollection<AlunoCurso> AlunosCursos { get; set; }
        }

        public class Curso
        {
            public int CodCurso { get; set; }
            public string Descricao { get; set; }
            public ICollection<AlunoCurso> AlunosCursos { get; set; }
        }

        public class AlunoCurso
        {
            public int CodAluno { get; set; }
            public CadastroAluno CadastroAluno { get; set; }
            public int CodCurso { get; set; }
            public Curso Curso { get; set; }
        }

        public class Venda
        {
            public int ID { get; set; }
            public DateTime  DataVenda { get; set; }
            public int IDCliente { get; set; }
        }
    }
}
