using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServices;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [Authorize]
    public class DespesasController : Controller
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        private readonly IDespesaServico _idespesaServico;

        public DespesasController(InterfaceDespesa interfaceDespesa,
            IDespesaServico idespesaServico)
        {
            _interfaceDespesa = interfaceDespesa;
            _idespesaServico = idespesaServico;
        }

        [HttpGet("/api/ListarDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDespesasUsuario(string emailUsuario)
        {
            return _interfaceDespesa.ListaDespesasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _idespesaServico.AdicionarDespesa(despesa);

            return despesa;
        }

        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _idespesaServico.AtualizarDespesa(despesa);

            return despesa;
        }

        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _interfaceDespesa.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<object> DeleteDespesa(int id)
        {
            try
            {
                var despesa = await _interfaceDespesa.GetEntityById(id);
                await _interfaceDespesa.Delete(despesa);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        [HttpGet("/api/CarregaGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            return await _idespesaServico.CarregarGraficos(emailUsuario);
        }
    }
}
