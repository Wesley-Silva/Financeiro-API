using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.ISistemaFinanaceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _iUsuarioSistemaFinanceiroServico;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, 
            IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiroServico)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _iUsuarioSistemaFinanceiroServico = usuarioSistemaFinanceiroServico;
        }

        [HttpGet("/api/ListaUsuariosSistemas")]
        [Produces("application/json")]
        public async Task<object> ListaUsuariosSistemas(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListaUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _iUsuarioSistemaFinanceiroServico.CadastrarUsuarioNoSistema(
                    new UsuarioSistemaFinanceiro
                    {
                        IdSistema = idSistema,
                        EmailUsuario = emailUsuario,
                        Administrador= false,
                        SistemaAtual = true
                    });

            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

                await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
