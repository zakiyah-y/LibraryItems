namespace LibraryItems.Services
{
    public interface ICrudService<T, U>
    {
  
        public IEnumerable<T> GetAll();
        public T Get(U id);
        public void Add(T element);
        public void Update(T oldElement, T newElement);
        public void Delete(U id);
    }
}
// This is an interface for CRUD enabled services