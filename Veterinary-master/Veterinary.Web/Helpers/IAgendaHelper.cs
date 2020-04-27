using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary.Web.Helpers
{
    public interface IAgendaHelper
    {
        Task AddDaysAsync(int days);
    }
}
