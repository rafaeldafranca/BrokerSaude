using BrokerService.Domain.helper;
using BrokerService.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Controllers.Base
{
    public class BrokerController : ControllerBase
    {
        protected MessageModel EnviarEmailCadastro(TipoUsuario typeUser, string email)
        {
            var novoEmail = new MessageModel();
            var body = new StringBuilder();
            
            body.AppendLine("<h1><b>Cadastro Realizado com sucesso!</b><h1>");
            body.AppendLine($"<p>Seu cadastro de {typeUser} está pronto para ser utilizado em nossa plataforma");
            body.AppendLine("<p>Equipe Boa Saude");
          
            novoEmail.From = "EmailService";
            novoEmail.To = email;
            novoEmail.Content = body.ToString();

            return novoEmail;

        }

        protected MessageModel EnviarEmailManifestacao(string codigo, string email)
        {
            var novoEmail = new MessageModel();
            var body = new StringBuilder();

            body.AppendLine("<h1><b>Sua manifestação foi criada com sucesso!</b><h1>");
            body.AppendLine($"<p>Acompanhe pelo seu token {codigo} até para colocar novas informações");
            body.AppendLine("<p>Equipe Boa Saude");

            novoEmail.From = "EmailService";
            novoEmail.To = email;
            novoEmail.Content = body.ToString();

            return novoEmail;

        }

        protected MessageModel EnviarEmailResposta(string codigo, string email)
        {
            var novoEmail = new MessageModel();
            var body = new StringBuilder();

            body.AppendLine("<h1><b>Sua resposta foi criada com sucesso!</b><h1>");
            body.AppendLine($"<p>Acompanhe pelo seu token {codigo} até para colocar novas informações");
            body.AppendLine("<p>Equipe Boa Saude");

            novoEmail.From = "EmailService";
            novoEmail.To = email;
            novoEmail.Content = body.ToString();

            return novoEmail;

        }

        protected IActionResult ReturnPackage(Func<dynamic> procedure, TipoUsuario typeUser = TipoUsuario.Todos, HttpStatusCode status = HttpStatusCode.OK,
            string message = null)
        {
            string chamada = $"{HttpContext.Request.Method} -  {HttpContext.Request.Path.Value} ";
            string RemoteConnection = HttpContext.Connection.RemoteIpAddress.ToString();

            Serilog.Log.Information($"*** Iniciando {chamada} para {RemoteConnection} ***");

            try
            {
                if (!ValidateUser(typeUser))
                    return StatusCode(401, "Esse usuário não tem acesso com a permissão atribuida");

                var result = procedure();

                if (result is ObjectResult)
                    return result;

                if (message == null)
                    return StatusCode((int)status, result);

                return StatusCode((int)status, new { mensagem = message });

            }
            catch (DomainException dEx) //erros gerados pelo domain.
            {
                var msgError = string.Join(", ", dEx.Errors.ToArray());
                Serilog.Log.Fatal(msgError, $"Server error {chamada} para {RemoteConnection}");
                return StatusCode(500, new { mensagem = msgError });
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                if (!string.IsNullOrEmpty(ex.InnerException?.Message))
                    errorMessage += $" => {ex.InnerException.Message}";

                Serilog.Log.Fatal(ex, $"Server error {chamada} para {RemoteConnection}");
                return StatusCode(500, new { mensagem = errorMessage });
            }

        }


        private bool ValidateUser(TipoUsuario type)
        {
            if (type == TipoUsuario.Todos) return true;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                //IEnumerable<Claim> claims = identity.Claims;
                return (identity.FindFirst("TypeUser").Value.ToLower() == type.ToString().ToLower());
            }
            return false;
        }
    }
}
