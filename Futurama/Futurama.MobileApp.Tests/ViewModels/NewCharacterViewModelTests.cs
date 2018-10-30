using Futurama.MobileApp.Models;
using Futurama.MobileApp.ViewModels;
using Futurama.Shared;
using Moq;
using Xunit;

namespace Futurama.MobileApp.Tests.ViewModels
{
    public class NewCharacterViewModelTests
    {
        [Fact]
        public void LoadCommand_populates_Actors()
        {
            var characterRepository = new Mock<ICharacterRepository>();

            var actors = new[] { new ActorDTO { Id = 42, Name = "actor" } };
            var actorRepository = new Mock<IActorRepository>();
            actorRepository.Setup(s => s.ReadAsync()).ReturnsAsync(actors);

            var viewModel = new NewCharacterViewModel(characterRepository.Object, actorRepository.Object);

            viewModel.LoadCommand.Execute(null);

            Assert.Equal(actors, viewModel.Actors);
        }
    }
}
