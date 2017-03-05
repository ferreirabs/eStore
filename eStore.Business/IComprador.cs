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
        ModelComprador Find(int? id);
        //IEnumerable<Entities.Comprador> Listar();
        ModelComprador Listar(int page, int pageSize);
        ModelComprador ListarPorFiltro(string valor, string tipo);
        //List<Endereco> GetEnderecos(int id_comprador);
        bool Editar(ModelView.ModelComprador comprador);
    }
}
