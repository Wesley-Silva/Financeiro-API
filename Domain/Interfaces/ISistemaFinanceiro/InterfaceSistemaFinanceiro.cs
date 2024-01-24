using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.ISistemaFinanaceiro
{
    public interface InterfaceSistemaFinanceiro : InterfaceGeneric<SistemaFinanceiro>
    {       
        Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario);
    }
}
