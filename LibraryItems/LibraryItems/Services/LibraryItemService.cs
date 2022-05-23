using LibraryItems.Data.Repositories;
using LibraryItems.Models;

namespace LibraryItems.Services
{
    public class LibraryItemService : ICrudService<LibraryItem, int>
    {
        private readonly ICrudRepository<LibraryItem, int> _libraryItemRepository;
        public LibraryItemService(ICrudRepository<LibraryItem, int> libraryItemRepository)
        {
            _libraryItemRepository = libraryItemRepository;
        }
        public void Add(LibraryItem element)
        {
            _libraryItemRepository.Add(element);
            _libraryItemRepository.Save();
        }
        public void Delete(int id)
        {
            _libraryItemRepository.Delete(id);
            _libraryItemRepository.Save();
        }
        public LibraryItem Get(int id)
        {
            return _libraryItemRepository.Get(id);
        }
        public IEnumerable<LibraryItem> GetAll()
        {
            return _libraryItemRepository.GetAll();
        }
        public void Update(LibraryItem old, LibraryItem newT)
        {
            //should correspond with what is in LibraryItem.cs
            old.Description = newT.Description;
            old.Name = newT.Name;
            old.Location = newT.Location;
            old.LengthOfBooking = newT.LengthOfBooking;
          //  old.Email = newT.Email;

            _libraryItemRepository.Update(old);
            _libraryItemRepository.Save();
        }
    }
}
