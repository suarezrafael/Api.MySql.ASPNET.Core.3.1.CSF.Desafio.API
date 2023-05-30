using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using CSF.Desafio.API.DbContexts;
using CSF.Desafio.API.Entities;
using CSF.Desafio.API.ResourceParameters;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using Slapper;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CSF.Desafio.API.Services
{
    public class ClienteRepository : IClienteRepository, IDisposable
    {
        private readonly DesafioContext _context;
        IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ClienteRepository(IConfiguration configuration, DesafioContext context, IMapper mapper)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration)); ;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
            GetSection("DesafioConnection").Value;
            return connection;
        }
        public Cliente GetCliente(int clienteId)
        {
            if (clienteId == 0)
            {
                throw new ArgumentNullException(nameof(clienteId));
            }
            return _context.Clientes.Where( w=>w.Id == clienteId).FirstOrDefault();
        }

        /// <summary>
        /// GET – Listar todos clientes cadastros na base:
        /// o Incluir filtro por COD_EMPRESA – Obrigatório
        /// o Incluir filtro por NOME – Opcional
        /// o Incluir filtro por CPF – Opcional
        /// o Incluir filtro por Cidade – Opcional
        /// o Incluir filtro por Estado – Opcional
        /// o Todos os filtros deverão ser queryString;
        /// </summary>
        /// <param name="clienteParameters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Cliente> GetClientes(ClienteParameters clienteParameters)
        {
            var connectionString = this.GetConnection();
            List<Cliente> clientes = new List<Cliente>();

            if (clienteParameters == null)
            {
                throw new ArgumentNullException(nameof(clienteParameters));
            }
            if (clienteParameters.CodEmpresa == 0)
            {
                throw new ArgumentNullException(nameof(clienteParameters.CodEmpresa));
            }

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT
                                       c.*,
                                       ce.*,
                                       e.*,
                                       ci.*
                                    FROM TB_CLIENTE c 
                                   INNER JOIN TB_CLIENTE_ENDERECO ce ON c.ID = ce.TB_CLIENTE_ID 
                                   INNER JOIN TB_ENDERECO e ON ce.TB_ENDERECO_ID = e.ID
                                   INNER JOIN TB_CIDADE ci ON e.TB_CIDADE_ID = ci.ID
                                   WHERE c.COD_EMPRESA = @CodEmpresa";

                    // Usa ExpandoObject para criar um objeto flexível
                    dynamic param = new System.Dynamic.ExpandoObject();
                    param.CodEmpresa  = clienteParameters.CodEmpresa;

                    if (!string.IsNullOrWhiteSpace(clienteParameters.Nome))
                    {
                        query += " AND c.NOME = @Nome";
                        param.Nome = clienteParameters.Nome.Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(clienteParameters.Cpf))
                    {
                        query += " AND c.CPF = @Cpf";
                        param.Cpf = clienteParameters.Cpf.Trim();
                    }
                        
                    if (!string.IsNullOrWhiteSpace(clienteParameters.Cidade))
                    {
                        query += " AND ci.NOME = @Cidade";
                        param.Cidade = clienteParameters.Cidade.Trim();
                    }
                        
                    if (!string.IsNullOrWhiteSpace(clienteParameters.Estado))
                    {
                        query += " AND e.ESTADO = @Estado";
                        param.Estado = clienteParameters.Estado.Trim();
                    }

                    var lookup = new Dictionary<int, Cliente>();

                    con.Query<Cliente, ClienteEndereco, Endereco,Cidade, Cliente>(
                        query,
                        (cliente, clienteEndereco, endereco,cidade) =>
                        {
                            if (!lookup.TryGetValue(cliente.Id, out var clienteAtual))
                            {
                                clienteAtual = cliente;
                                clienteAtual.ClienteEnderecos = new List<ClienteEndereco>();
                                clienteEndereco.Endereco = endereco;
                                endereco.Cidade = cidade;
                                endereco.CidadeId = cidade.Id;
                                lookup.Add(clienteAtual.Id, clienteAtual);
                            }

                            clienteAtual.ClienteEnderecos.Add(clienteEndereco);
                            
                            return clienteAtual;
                        },(object)param
                    );

                    return lookup.Values;
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public void AddCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            
            _context.Clientes.Add(cliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            var clienteRepo = _context.Clientes
                .Include(c => c.ClienteEnderecos)
                    .ThenInclude(ce=>ce.Endereco)
                .FirstOrDefault(c => c.Id == cliente.Id);

            if (clienteRepo != null)
            {
                var clienteEnderecos = cliente.ClienteEnderecos.ToList();
                foreach (var clienteEndereco in clienteEnderecos)
                {
                    var endereco = clienteEndereco.Endereco;
                    _context.ClientesEnderecos.Remove(clienteEndereco);
                    _context.Enderecos.Remove(endereco);
                }
                _context.Clientes.Remove(clienteRepo);
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // destruir recurso quando preciso
            }
        }

        public bool ClienteExistePorEmpresa(int codEmpresa, string cpf)
        {
            if (codEmpresa == 0)
            {
                throw new ArgumentNullException(nameof(codEmpresa));
            }

            if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentNullException(nameof(cpf));
            }

            return _context.Clientes.Where(w => w.CodEmpresa == codEmpresa && w.Cpf.Equals(cpf)).Any();

        }
    }
}
