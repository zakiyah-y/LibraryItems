using LibraryItems.Data;
using LibraryItems.Data.Repositories;
using LibraryItems.Models;

namespace LibraryItems.Data.Repositories
{
    public class LibraryRepository : ICrudRepository<Library, int>
    {
        private readonly LibraryItemContext _libraryContext;
        public LibraryRepository(LibraryItemContext libraryContext)
        {
            _libraryContext = libraryContext ?? throw new
            ArgumentNullException(nameof(libraryContext));
        }
        public void Add(Library element)
        {
            _libraryContext.Libraries.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _libraryContext.Libraries.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _libraryContext.Libraries.Any(u => u.Id == id);
        }
        public Library Get(int id)
        {
            return _libraryContext.Libraries.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Library> GetAll()
        {
            return _libraryContext.Libraries.ToList();
        }
        public bool Save()
        {
            return _libraryContext.SaveChanges() > 0;
        }
        public void Update(Library element)
        {
            _libraryContext.Update(element);
        }
    }
}

