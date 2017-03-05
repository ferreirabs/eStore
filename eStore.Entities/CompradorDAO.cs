using eStore.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStore.Entities
{
    public class CompradorDAO : ICompradorDAO
    {

        eStoreContext db = new eStoreContext();

        public IEnumerable<Comprador> Listar()
        {
            return db.Comprador.ToList();
        }

        public IEnumerable<Comprador> ListarPorNome(string nome)
        {
            return db.Comprador.Where(c => c.nome.Contains(nome)).ToList();
        }

        public IEnumerable<Comprador> ListarPorEmail(string email)
        {
            return db.Comprador.Where(c => c.email.Contains(email)).ToList();
        }

        public IEnumerable<Comprador> ListarPorCpf(string cpf)
        {
            return db.Comprador.Where(c => c.cpf.Contains(cpf)).ToList();
        }
        
        public IEnumerable<Comprador> ListarPorCnpj(string cnpj)
        {
            return db.Comprador.Where(c => c.cnpj.Contains(cnpj)).ToList();
        }

        public Comprador Find(int? id)
        {
            try
            {
                return db.Comprador.FirstOrDefault(c => c.id == id);
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}