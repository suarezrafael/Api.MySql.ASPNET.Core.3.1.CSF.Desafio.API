using System.Collections.Generic;
using System;
using CSF.Desafio.API.Entities;
using CSF.Desafio.API.ResourceParameters;

namespace CSF.Desafio.API.Services
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes(ClienteParameters param);  
        Cliente GetCliente(int clienteId);
        //IEnumerable<Cliente> GetClientes(IEnumerable<int> clienteIds);
        void AddCliente(Cliente cliente);
        void DeleteCliente(Cliente cliente);
        //void UpdateCliente(Cliente cliente);
        bool ClienteExistePorEmpresa(int codEmpresa, string cpf);
        bool Save();
    }
}
