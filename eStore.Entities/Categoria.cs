using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    [Serializable]
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
    }
}