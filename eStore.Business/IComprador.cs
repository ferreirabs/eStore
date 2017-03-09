using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using eStore.ModelView;

namespace eStore.Business
{
    public interface IComprador
    {
        /*bool Criar(Entities.Comprador comprador);
        bool Remover(Entities.Comprador comprador);
        bool Remover(int id);
        bool Editar(Entities.Comprador comprador, int state);
        bool Editar(ModelView.ModelComprador comprador);*/
        ModelCompradores Find(int? id);
        //IEnumerable<Entities.Comprador> Listar();
        ModelCompradores Listar(int page, int pageSize);
        ModelCompradores ListarPorFiltro(string valor, string tipo);
        //List<Endereco> GetEnderecos(int id_comprador);
        bool Editar(ModelView.ModelCompradores comprador);
        bool Criar(Entities.Comprador comprador);
        Entities.Comprador Builder(string nome, string sobrenome, string email, string sexo, string senha, string conf_senha);
    }
}
