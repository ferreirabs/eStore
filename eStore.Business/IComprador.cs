using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;

namespace eStore.Business
{
    public interface IComprador
    {
        bool Create(Entities.Comprador comprador);
        Entities.Comprador Find(int? id);
    }
}
