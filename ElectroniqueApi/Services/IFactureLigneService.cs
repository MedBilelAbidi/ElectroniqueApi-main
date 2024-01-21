using ElectroniqueApi.Model;

namespace ElectroniqueApi.Services
{
    public interface IFactureLigneService<T>
    {
        Task<T> Get(int Id);
        Task<List<T>> GetAll();

        Task<List<T>> Add(List<T> t);
        Task<T> Update(T t);
        Task<T> Delete(int Id);
        Task<List<T>> GetByClinetId(int clientId);
    }
}
