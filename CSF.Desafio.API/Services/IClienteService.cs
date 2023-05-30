using CSF.Desafio.API.Entities;
using System.Collections.Generic;

namespace CSF.Desafio.API.Services
{
    public interface IClienteService
    {
        public List<Cliente> GetClientes();
        public Cliente GetCliente(int id);
        public bool AddCliente(Cliente cliente);
        public bool UpdateCliente(int id, Cliente cliente);
        public bool DeleteCliente(int id);
    }
}
