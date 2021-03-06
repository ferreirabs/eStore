﻿using eStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.ModelView
{
    public class ModelCarrinho
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public decimal preco_carrinho { get; set; }

        public int total_produtos { get; set; }

        public decimal total_frete { get; set; }

        public decimal total { get; set; }

        public IEnumerable<Produto> lista_produtos { get; set; }

        public ModelCarrinho() {
            lista_produtos = new List<Produto>();
        }

        public ModelCarrinho(Carrinho carrinho)
        {
            this.Id = carrinho.id;
            this.Codigo = carrinho.codigo;
            this.preco_carrinho = 0;
            this.total_produtos = 0;
            this.total_frete = 15.50M;
            this.total = GetTotalCarrinho();
            lista_produtos  = new List<Produto>();
        }

        public decimal GetTotalCarrinho(){

            return this.total_frete + this.preco_carrinho;
        }

    }
}