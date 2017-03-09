using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStore.Entities;
using eStore.ModelView;
using PagedList;
using AutoMapper;

namespace eStore.Business
{
    public class Comprador : IComprador
    {
        public DicionarioErros msgErro =  new DicionarioErros();

        public Comprador() {
            AutoMapperConfig.ConfigMappings();
        }

        public ModelCompradores Listar(int page, int pageSize)
        {
            try
            {
                ModelCompradores modelComprador = new ModelCompradores();
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

        public ModelCompradores ListarPorFiltro(string valor, string tipo)
        {
            try
            {
                ModelCompradores modelComprador = new ModelCompradores();
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

        public ModelCompradores Find(int? id)
        {
            try
            {
                CompradorDAO CompradorDAO = new CompradorDAO();
                var comprador = CompradorDAO.Find(id);
                List<Entities.Comprador> lcomprador = new List<Entities.Comprador>();
                lcomprador.Add(comprador);
                ModelCompradores modelComprador = new ModelCompradores(lcomprador.FirstOrDefault());
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

        public bool Editar(ModelView.ModelCompradores comprador)
        {
            try
            {
                CompradorDAO c = new CompradorDAO();
                var _comprador = Mapper.Map<Entities.Comprador>(comprador);
                _comprador.telefone1 = null;
                _comprador.telefone2 = null;
                _comprador.nascimento = new DateTime(1988, 3, 21);
                return c.Salvar(_comprador);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }
        }

        public Entities.Comprador Logar(string email, string senha) 
        {
            CompradorDAO c = new CompradorDAO();
            var _comprador = c.Find(email, senha);
            return _comprador;
        
        }

        public bool Criar(Entities.Comprador comprador)
        {
            try
            {
                CompradorDAO c = new CompradorDAO();
                if(c.ListarPorEmail(comprador.email).FirstOrDefault(e => e.email == comprador.email) == null)
                    return c.Criar(comprador);

                return false;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
                return false;
            }

        }

        public Entities.Comprador Builder(string nome, string sobrenome, string email, string sexo, string senha, string conf_senha) 
        {
            try
            {
                Entities.Comprador _comprador = new Entities.Comprador();
                _comprador.nome = nome + " " + sobrenome;
                _comprador.email = email;
                _comprador.senha = senha;
                _comprador.nascimento = new DateTime(1990, 03, 21);
                _comprador.data_cadastro = DateTime.Now;
                _comprador.bloqueado = false;
                return _comprador;
            }
            catch (Exception)
            {
               
                return null;
            }
        }

    }
}