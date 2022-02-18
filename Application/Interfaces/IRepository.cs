using Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Create(T element);
        Task<int> Update(T element);
        Task<bool> DeleteLogic(int id);
        Task<bool> Delete(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllPaginated(int page, int sizePage);
        Task<T> GetSingle(int id);
        Task<IEnumerable<T>> Search(string text);
        bool Exist(int id);
    }
}
