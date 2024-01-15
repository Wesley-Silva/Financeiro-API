using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.ISistemaFinanaceiro
{
    public interface InterfaceSistemaFinanaceiro : InterfaceGeneric<SistemaFinanceiro>
    {       
        Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario);
    }
}
