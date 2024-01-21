namespace ElectroniqueApi.Services
{
    public interface ICategorieService<T>
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T t);
        Task<T> Update(T t);
        Task<T> Delete(int Id);
    }
}
