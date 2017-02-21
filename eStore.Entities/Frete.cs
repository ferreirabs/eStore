using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    [Serializable]
    public class Frete
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "O id deve ser numérico")]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O código do frete é obrigatório")]
        public string codigo { get; set; }

    }
}