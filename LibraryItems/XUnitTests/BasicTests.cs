using LibraryItems.Controllers;
using LibraryItems.Models;
using Moq;
using Xunit;

namespace XUnitTests
{
    public class BasicTests
    {
        private LibraryItemController controller;
        [Fact]
        public void Delete_1_Item_Ok()
        {
            //arrange
            var libraryMock = new Mock<LibraryItemController>(); //create a mock
            //act
           // libraryMock.Setup(s => s.Delete(It.IsAny<int>()));
            var result = controller.Delete(It.IsAny<int>());
            //assert
            Assert.NotNull(result);

        }

        
    }
}