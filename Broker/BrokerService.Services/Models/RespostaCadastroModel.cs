
using BrokerService.Services.Models;
using System;
using System.Collections.Generic;

namespace Cadastro.Domain.Models
{
    public class RespostaCadastroModel
    {
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }

        public RespostaCadastroModel(Guid usuarioId, string descricao, string codigo)
        {
            UsuarioId = usuarioId;
            Descricao = descricao;
            Codigo = codigo;
        }
    }
}