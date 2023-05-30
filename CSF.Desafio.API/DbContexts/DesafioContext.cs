using CSF.Desafio.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSF.Desafio.API.DbContexts
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options)
              : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEndereco>()
                .HasKey(x => new { x.ClienteId, x.EnderecoId });

            //definindo o relacionamento explicitamente
            modelBuilder.Entity<ClienteEndereco>()
            .HasOne(bc => bc.Cliente)
             .WithMany(b => b.ClienteEnderecos)
              .HasForeignKey(bc => bc.ClienteId);

            modelBuilder.Entity<ClienteEndereco>()
                .HasOne(bc => bc.Endereco)
                .WithMany(c => c.ClienteEnderecos)
                 .HasForeignKey(bc => bc.EnderecoId);

            modelBuilder.Entity<Cidade>().HasData(
              new Cidade
              {
                  Id = 1,
                  Nome = "Santa Cruz do Sul",
                  Estado = "RS"
                  },
              new Cidade
              {
                  Id = 2,
                  Nome = "Vera Cruz",
                  Estado = "RS"
              });

            // seed the database with dummy data
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente()
                {
                    Id = 1,
                    Nome = "Rafael Vieira Suarez",
                    Cpf = "01552764095",
                    CodEmpresa = 1,
                    DataNascimento = new DateTime(1650, 7, 23),
                    Email = "rafaelv_s@hotmail.com",
                    Rg = "6096800117",
                    Telefone = "51999708050"
                    
                },
                new Cliente()
                {
                    Id = 2,
                    Nome = "Caroline Seer Splett",
                    Cpf = "00460801040",
                    CodEmpresa = 1,
                    DataNascimento = new DateTime(1987, 7, 30),
                    Email = "caroline_splett@gmail.com",
                    Rg = "6096800618",
                    Telefone = "51996013891"

                }

                );

            modelBuilder.Entity<Endereco>().HasData(
              new Endereco
              {
                  Id = 1,
                  Bairro = "Ana Nery",
                  CidadeId = 1,
                  Cep = "96835422",
                  Complemento = "150 m",
                  Numero = "3322",
                  Rua = "Euclides Kliemann",
                  TipoEndereco = 1
              },
              new Endereco
              {
                  Id = 2,
                  Bairro = "Centro",
                  CidadeId = 2,
                  Cep = "96835344",
                  Complemento = "456 A",
                  Numero = "3322",
                  Rua = "Euclides Kliemann",
                  TipoEndereco = 2

              });

              modelBuilder.Entity<ClienteEndereco>().HasData(
              new ClienteEndereco
              {
                  Id = 1,
                  ClienteId = 1,
                  EnderecoId = 1
              },
              new ClienteEndereco
              {
                  Id = 2,
                  ClienteId= 2,
                  EnderecoId = 2
              });

            base.OnModelCreating(modelBuilder);
        }
    }
}
