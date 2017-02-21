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

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [MaxLength(300, ErrorMessage = "O número máximo de caracteres permitidos é 300.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O tipo do frete é obrigatório")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "A ordem de serviço é obrigatória")]
        public string ordem { get; set; }

        [Required(ErrorMessage = "O status do frete é obrigatório")]
        public string status { get; set; }

    }
}