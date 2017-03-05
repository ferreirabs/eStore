using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    [Serializable]
    public class Comprador
    {
        [Key]
        public int id { get; set; }

        public string codigo { get; set; }
        public string nome { get; set; }
        public string email {get; set;}
        public string senha {get; set;}
        public DateTime nascimento { get; set; }
        public string profissao { get; set; }
        public string rg { get; set; }
        public string rg_uf { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public TipoPessoa tipo { get; set; }
        public List<Endereco> enderecos { get; set;}
        public Telefone telefone1 { get; set; }
        public Telefone telefone2 { get; set; }
        public DateTime data_cadastro { get; set; }
        public bool bloqueado { get; set; }
    }

    public class TipoPessoa
    {
        [Key]
        public int id { get; set; }
        
        public bool fisica { get; set; }
        public bool juridica { get; set; } 
    }

    public class Endereco
    {
        [Key]
        public int id { get; set; }
        public int comprador_id { get; set; }

        public string cep { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string referencia { get; set; }
        public bool principal { get; set; }
        

    }

    public class Telefone
    {
        [Key]
        public int id { get; set; }
        
        public int ddd { get; set; }
        public int numero { get; set; }

    }
}
