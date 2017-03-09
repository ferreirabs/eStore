using eStore.Entities.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var comprador = db.Comprador.FirstOrDefault(c => c.id == id);
                comprador.enderecos = GetEnderecos(id);
                return comprador;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Comprador Find(string email, string senha)
        {
            try
            {
                var comprador = db.Comprador.FirstOrDefault(c => c.email == email && c.senha == senha);
                if (comprador.id != 0)
                {
                    comprador.enderecos = GetEnderecos(comprador.id);
                }
                else
                {
                    comprador = null;

                }

                return comprador;
            
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Endereco> GetEnderecos(int? id_comprador)
        {
            try
            {
                return db.Endereco.Where(e => e.comprador_id == id_comprador).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Salvar(Comprador comprador)
        {
            try
            {
                db.Entry(comprador).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Criar(Comprador comprador)
        {
            try
            {
                db.Comprador.Add(comprador);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

    }
}