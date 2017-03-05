using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using eStore.ModelView;
using PagedList;

namespace eStore.Business
{
    public class Comprador : IComprador
    {
        public DicionarioErros msgErro =  new DicionarioErros();

        public Comprador() {
            AutoMapperConfig.ConfigMappings();
        }

        public ModelComprador Listar(int page, int pageSize)
        {
            try
            {
                ModelComprador modelComprador = new ModelComprador();
                CompradorDAO CompradorDAO = new CompradorDAO();
                var LCompradores = CompradorDAO.Listar();
                modelComprador.lista_compradores = new PagedList<Entities.Comprador>(LCompradores, page, pageSize);
                modelComprador.total_compradores = modelComprador.lista_compradores.Count();

                return modelComprador;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        public ModelComprador ListarPorFiltro(string valor, string tipo)
        {
            try
            {
                ModelComprador modelComprador = new ModelComprador();
                CompradorDAO CompradorDAO = new CompradorDAO();
                var LCompradores = ListarPorTipo(valor, tipo, CompradorDAO);
                modelComprador.lista_compradores = new PagedList<Entities.Comprador>(LCompradores, 1, 10);
                modelComprador.total_compradores = modelComprador.lista_compradores.Count();

                return modelComprador;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }

        private IEnumerable<Entities.Comprador> ListarPorTipo(string valor, string tipo, CompradorDAO CompradorDAO)
        {
            switch (tipo)
            {
                case "nome":
                    return CompradorDAO.ListarPorNome(valor);
                case "email":
                    return CompradorDAO.ListarPorEmail(valor);
                case "cpf":
                    return CompradorDAO.ListarPorCpf(valor);
                case "cnpj":
                    return CompradorDAO.ListarPorCnpj(valor);
                default:
                    return CompradorDAO.ListarPorNome("");
            }
        }

        public ModelComprador Find(int? id)
        {
            try
            {
                CompradorDAO CompradorDAO = new CompradorDAO();
                var comprador = CompradorDAO.Find(id);
                List<Entities.Comprador> lcomprador = new List<Entities.Comprador>();
                lcomprador.Add(comprador);

                ModelComprador modelComprador = new ModelComprador(lcomprador.FirstOrDefault());
                modelComprador.lista_compradores = new PagedList<Entities.Comprador>(lcomprador, 1, 10);
                modelComprador.total_compradores = modelComprador.lista_compradores.Count();
                return modelComprador;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return null;
            }

        }
    
    }
}