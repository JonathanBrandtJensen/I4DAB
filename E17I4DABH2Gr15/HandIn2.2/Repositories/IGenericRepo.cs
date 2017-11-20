using System;

namespace HandIn2._2.Repositories
{
    public interface IGenericRepo<T>
    {
        T Get(string id);
        string Create(T objectToCreate);
        bool Update(T objectToUpdate);
        bool Delete(Guid objectToDeleteId);
    }
}