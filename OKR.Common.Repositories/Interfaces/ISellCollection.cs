using OKR.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Repositories.Interfaces
{
    public interface ISellCollection
    {
        Task InsertSell(Sell sell);
        Task UpdateSell(Sell sell);
        Task DeleteSell(string id);
        Task<List<Sell>> GetAllSell();
        Task<Sell> GetSellById(string id);

    }
}
