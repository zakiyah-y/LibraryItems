using LibraryItems.Models;

namespace LibraryItems.Data.Repositories
{
    public class LibItemRepository : ICrudRepository<LibraryItem, int>
    {
        private readonly LibraryItemContext _libraryItemContext;
        public LibItemRepository(LibraryItemContext libraryItemContext)
        {
            _libraryItemContext = libraryItemContext ?? throw new
            ArgumentNullException(nameof(libraryItemContext));
        }
        public void Add(LibraryItem element)
        {
            _libraryItemContext.LibraryItems.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _libraryItemContext.LibraryItems.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _libraryItemContext.LibraryItems.Any(u => u.Id == id);
        }
        public LibraryItem Get(int id)
        {
            return _libraryItemContext.LibraryItems.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<LibraryItem> GetAll()
        {
            return _libraryItemContext.LibraryItems.ToList();
        }
        public bool Save()
        {
            return _libraryItemContext.SaveChanges() > 0;
        }
        public void Update(LibraryItem element)
        {
            _libraryItemContext.Update(element);
        }
    }
}
