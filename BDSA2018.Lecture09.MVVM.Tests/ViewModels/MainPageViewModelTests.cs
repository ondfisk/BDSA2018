using BDSA2018.Lecture09.MVVM.Model;
using BDSA2018.Lecture09.MVVM.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace BDSA2018.Lecture09.MVVM.Tests.ViewModels
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        public async Task Init_loads_Albums_from_repository()
        {
            var albums = new[] { new Album() };
            var repository = new Mock<IAlbumRepository>();
            repository.Setup(s => s.ReadAsync()).ReturnsAsync(albums);

            var vm = new MainPageViewModel(repository.Object);

            await vm.Init();

            CollectionAssert.AreEqual(albums, vm.Albums);
        }
    }
}
