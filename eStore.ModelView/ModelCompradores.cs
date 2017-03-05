using eStore.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelComprador
    {

        public int Id { get; set; }

        [Display(Name = "Código:")]
        public string Codigo { get; set; }
        [Display(Name = "Nome Completo:")]
        public string Nome { get; set; }
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Senha:")]
        public string Senha { get; set; }
        [Display(Name = "Nascimento:")]
        public DateTime Nascimento { get; set; }
        [Display(Name = "Profissao:")]
        public string Profissao { get; set; }
        [Display(Name = "RG:")]
        public string RG { get; set; }
        [Display(Name = "RG/UF")]
        public string rg_uf { get; set; }
        [Display(Name = "CPF:")]
        public string CPF { get; set; }
        [Display(Name = "CNPJ:")]
        public string CNPJ { get; set; }
        [Display(Name = "Tipo de Pessoa:")]
        public TipoPessoa Tipo { get; set; }
        [Display(Name = "Enderecos:")]
        public List<Endereco> Enderecos { get; set; }
        [Display(Name = "Telefone Fixo:")]
        public Telefone Telefone1 { get; set; }
        [Display(Name = "Telefone Alternativo:")]
        public Telefone Telefone2 { get; set; }
        [Display(Name = "Data Cadastro:")]
        public string DataCadastro { get; set; }
        [Display(Name = "Bloqueado?")]
        public bool Bloqueado { get; set; }
        public PagedList<Comprador> lista_compradores { get; set; }
        public int total_compradores { get; set; }

        public ModelComprador() {
            lista_compradores = new PagedList<Comprador>(null,1,1);
            Tipo = new TipoPessoa();
            Enderecos = new List<Endereco>();
            Telefone1 = new Telefone();
            Telefone2 = new Telefone();
            Nascimento = new DateTime();
        }

        public ModelComprador(Comprador comprador)
        {
            Id = comprador.id;
            Codigo = comprador.codigo;
            Nome = comprador.nome;
            Email = comprador.email;
            Senha = comprador.senha;
            Nascimento = comprador.nascimento;
            Profissao = comprador.profissao;
            RG = comprador.rg;
            rg_uf = comprador.rg_uf;
            CPF = comprador.cpf;
            CNPJ = comprador.cnpj;
            Tipo = comprador.tipo;
            Enderecos = comprador.enderecos;
            Telefone1 = comprador.telefone1;
            Telefone2 = comprador.telefone2;
            DataCadastro = comprador.data_cadastro.ToString();
            Bloqueado = comprador.bloqueado;
            DataCadastro = comprador.data_cadastro.ToString();
            lista_compradores = new PagedList<Comprador>(null, 1, 1);
        }

    }
}