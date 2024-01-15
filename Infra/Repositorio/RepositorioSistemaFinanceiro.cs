using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.ISistemaFinanaceiro;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanaceiro
    {
        public Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
