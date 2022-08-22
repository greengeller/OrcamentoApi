using OrcamentoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IQueryName<TEntity>
    {
        TEntity GetName(string nome);
    }
}
