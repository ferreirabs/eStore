﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using eStore.ModelView;

namespace eStore.Business
{
    public interface ICategoria
    {
        bool Criar(Entities.Categoria categoria);
        bool Remover(Entities.Categoria categoria);
        bool Remover(int id);
        bool Editar(Entities.Categoria categoria, int state);
        bool Editar(ModelView.ModelCategoria categoria);
        ModelCategoria Find(int? id);
        IEnumerable<Entities.Categoria> Listar();
        ModelCategoria Listar(int page, int pageSize);
        ModelCategoria ListarPorFiltro(string valor, string tipo);

    }
}