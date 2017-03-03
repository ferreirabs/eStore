using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Business
{
    public class DicionarioErros
    {
        public Dictionary<string, string> dicErros = new Dictionary<string, string>();

        public DicionarioErros()
        {
            dicErros.Add("CAMPOS_OBRIGATORIOS", "Campos obrigatórios inválidos!");
            dicErros.Add("EXECUTAR_ACAO", "Ocorreu um erro ao executar a ação! Tente novamente.");
        }

        public string Get(string key)
        {
            return dicErros[key];
        }
    }
}