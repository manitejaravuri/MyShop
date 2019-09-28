using System.Linq;
using Myshop.Core.Models;

namespace Myshop.core.contracts
{
    public interface IRepositary<T> where T : BaseEntity
    {
        IQueryable<T> collection();
        void commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}