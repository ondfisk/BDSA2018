using BDSA2018.Lecture09.MVVM.Model;
using BDSA2018.Lecture09.MVVM.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BDSA2018.Lecture09.MVVM.Tests.ViewModels
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        public void Ctor_loads_Albums_from_repository()
        {
            var albums = new[] { new Album() };
            var repository = new Mock<IAlbumRepository>();

            var vm = new MainPageViewModel(repository.Object);

            Assert.Equals(albums, vm.Albums);
        }
    }
}
