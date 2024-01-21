namespace ElectroniqueApi.Services
{
    public interface IProduitService<T>
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T t);
        Task<T> Update(T t, int id);
        Task<T> Delete(int Id);
    }
}
