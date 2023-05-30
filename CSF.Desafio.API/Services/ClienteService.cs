using CSF.Desafio.API.DbContexts;
using CSF.Desafio.API.Entities;
using CSF.Desafio.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSF.Desafio.API.Services
{
    public class ClienteService : IClienteService
    {
        public DesafioContext _context;

        public ClienteService(DesafioContext context)
        {
            _context = context;
        }

        public List<Cliente> GetClientes()
        {
            return _context.Clientes.ToList<Cliente>();
        }

        public Cliente GetCliente(int id)
        {
            var listagem = _context.Clientes.Where(p => p.Id == id);

            if (listagem.Any())
            {
                return listagem.First();
            }
            else
            {
                return null;
            }
        }

        public bool AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCliente(int id, Cliente cliente)
        {
            Cliente clienteBase = _context.Clientes.Single(p => p.Id == id);

            if (clienteBase != null)
            {
                _context.Attach<Cliente>(clienteBase);

                clienteBase.Nome = cliente.Nome;
    

                _context.Clientes.Update(clienteBase);
                _context.SaveChanges();
                
            }
            return true;
        }

        public bool DeleteCliente(int id)
        {
            Cliente clienteBase = _context.Clientes.Single(p => p.Id == id);

            if (clienteBase != null)
            {
                _context.Clientes.Remove(clienteBase);
                _context.SaveChanges();
            }
            return true;
        }
    }
}
