using EntityLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGoodRepository
    {
       // Task<T> Get(string code);
        Task<Goods> GetByCode(string code);
    }
}
