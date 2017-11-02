using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingApi.Repositories
{
    public interface IGenericRepository<T>
    {
        T GetById(string id);
        IEnumerable<T> GetList();
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);

    }
}
