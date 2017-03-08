using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    [Serializable]
    public class Produto
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "O id deve ser numérico")]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O código do produto é obrigatório")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [MaxLength(300, ErrorMessage = "O número máximo de caracteres permitidos é 300.")]
        public string nome { get; set; }

        //[RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "O preço do produto é obrigatório")]
        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        [Range(0, 10000000, ErrorMessage = "O valor máximo deve ser possuir até 10 digitos")]
        public decimal preco { get; set; }

        [MaxLength(8000, ErrorMessage = "O número máximo de caracteres permitidos é 8000.")]
        public string descricao { get; set; }

        [Range(0, 9999999999, ErrorMessage = "O valor máximo deve ser possuir até 10 digitos")]
        public int estoque { get; set; }

        public int ordem { get; set; }
        
        public bool bloqueado { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}