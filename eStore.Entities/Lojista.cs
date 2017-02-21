using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    
        [Serializable]
        public class Lojista
        {
            [RegularExpression(@"^\d+$", ErrorMessage = "O id deve ser numérico")]
            [Key]
            public int id { get; set; }

            public string nome { get; set; }

        }

        [Serializable]
        public class LogInLojista
        {



            [Required]
            //[Display(Nome = "Nome")]
            public string Nome { get; set; }

            [Required]
            [DataType(DataType.Password)]
            //[Display(Name = "Password")]
            public string Senha { get; set; }

            //[Display(Name = "Remember me?")]
            public bool Lembrar { get; set; }

        }
    
}