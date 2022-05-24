using LibraryItems.Data.Repositories;
using LibraryItems.Models;
using LibraryItems.Services;

namespace LibraryItems.Services
{
    public class LibraryService : ICrudService<Library, int>
    {
        private readonly ICrudRepository<Library, int> _libraryRepository;
        public LibraryService(ICrudRepository<Library, int> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public void Add(Library element)
        {
            _libraryRepository.Add(element);
            _libraryRepository.Save();
        }
        public void Delete(int id)
        {
            _libraryRepository.Delete(id);
            _libraryRepository.Save();
        }
        public Library Get(int id)
        {
            return _libraryRepository.Get(id);
        }
        public IEnumerable<Library> GetAll()
        {
            return _libraryRepository.GetAll();
        }
        public void Update(Library old, Library newT)
        {
        
            old.LibraryName = newT.LibraryName;
            old.Description = newT.Description;
            old.Location = newT.Location;
           // old.LengthOfBooking = newT.LengthOfBooking;
            //  old.Email = newT.Email;

            _libraryRepository.Update(old);
            _libraryRepository.Save();
        }
    }
}
