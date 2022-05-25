using LibraryItems.Models;
using Xunit;

namespace XUnitTests
{
    public class BasicTests
    {
        [Fact]
        public void Add_1_Item_Ok()
        {
            LibraryItem libraryItem = new LibraryItem();
            libraryItem.Name = "The Hunger Games: Mockingjay";
        }

        public void Delete_1_Item_Ok()
        {
        }
    }
}