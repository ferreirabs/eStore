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
        public int id { get; private set; }

        public string codigo { get; set; }
        public string nome { get; set; }
    }
}