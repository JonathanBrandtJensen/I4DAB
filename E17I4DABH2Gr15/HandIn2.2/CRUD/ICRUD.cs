using System;
using System.Linq;
using System.Threading.Tasks;

namespace HandIn2._2.CRUD
{
    public interface ICRUD<T>
    {
        Task<string> CreateDocument(T objectToCreate);
        Task<T> ReadDocument(string idOfObject);
        Task<bool> ReplaceDocument(T objectToReplace);
        Task<bool> DeleteDocument(Guid objectToDelete);
        IOrderedQueryable<T> Query();
    }
}