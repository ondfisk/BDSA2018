﻿using BDSA2018.Lecture07.Models;
using BDSA2018.Lecture07.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BDSA2018.Lecture07.Web.Tests.Controllers
{
    public class CharactersControllerTests
    {
        [Fact]
        public async Task Get_given_existing_returns_dto()
        {
            var dto = new CharacterDTO();
            var repository = new Mock<ICharacterRepository>();
            repository.Setup(s => s.FindAsync(42)).ReturnsAsync(dto);

            var controller = new CharactersController(repository.Object);

            var get = await controller.Get(42);

            Assert.Equal(dto, get.Value);
        }

        [Fact]
        public async Task Get_given_non_existing_returns_NotFound()
        {
            var dto = new CharacterDTO();
            var repository = new Mock<ICharacterRepository>();

            var controller = new CharactersController(repository.Object);

            var get = await controller.Get(42);

            var result = get.Result;

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_returns_all_characters()
        {
            var dto = new CharacterDTO();
            var dtos = new[] { dto }.AsQueryable().BuildMock();
            var repository = new Mock<ICharacterRepository>();
            repository.Setup(s => s.Read()).Returns(dtos.Object);

            var controller = new CharactersController(repository.Object);

            var get = await controller.Get();

            Assert.Equal(dto, get.Value.Single());
        }
    }
}
