using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using eStore.Entities;

namespace eStore.Model
{
    [Serializable]
    public class ModelCategoria : Categoria
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }

        public ModelCategoria() { }

        public ModelCategoria(Categoria categoria)
        {

            this.id = categoria.id;
            this.codigo = categoria.codigo;
            this.nome = categoria.nome;

        }
    }

}