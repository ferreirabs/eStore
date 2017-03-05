using System;
using System.Collections.Generic;
namespace eStore.Entities
{
    public interface ICompradorDAO
    {
        IEnumerable<Comprador> Listar();
        IEnumerable<Comprador> ListarPorNome(string nome);
        IEnumerable<Comprador> ListarPorEmail(string email);
        IEnumerable<Comprador> ListarPorCpf(string cpf);
        IEnumerable<Comprador> ListarPorCnpj(string cnpj);
        List<Endereco> GetEnderecos(int? id_comprador);
        /*bool Criar(Comprador Comprador);
        bool Remover(Comprador Comprador);
        bool Editar(Comprador Comprador, int state);*/
        bool Salvar(Comprador Comprador);
    }
}
