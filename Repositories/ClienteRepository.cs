using Clientes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Shared.Repositories
{
    public interface ClienteRepository
    {
        List<Cliente> GetAll();
        void SaveAll(List<Cliente> clients);
    }
}
