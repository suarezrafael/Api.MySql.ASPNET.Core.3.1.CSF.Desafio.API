using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Runtime.ConstrainedExecution;

namespace CSF.Desafio.API.ResourceParameters
{
    /// <summary>
    ///  GET – Listar todos clientes cadastros na base:
    /// o Incluir filtro por COD_EMPRESA – Obrigatório
    /// o Incluir filtro por NOME – Opcional
    /// o Incluir filtro por CPF – Opcional
    /// o Incluir filtro por Cidade – Opcional
    /// o Incluir filtro por Estado – Opcional
    /// o Todos os filtros deverão ser queryString;
    /// </summary>
    public class ClienteParameters
    {
        [BindRequired]
        public int CodEmpresa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        
    }
}
