namespace JixhDb.Test.Controllers
{

    using FluentAssertions;
    using JixhDb.Data;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Comments.Implementations;
    using JixhDb.Services.Movies.Implementations;
    using JixhDb.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Mocks;
    using Moq;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    public class CommentsControllerTest
    {

        [Fact]
        public async Task GetAllShouldReturnNotFound()
        {
            // Arrange
            var userManager = UserManagerMock.New;
            var controller = new CommentsController(new CommentsService(GetDatabase()), new MovieService(GetDatabase()), null);

            // Act
            var result = controller.GetAll("Username");

            // Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetAllShouldJson()
        {
            // Arrange
            var db = GetDatabase();
            var userManager = UserManagerMock.New;
            var controller = new CommentsController(new CommentsService(db), new MovieService(db), null);

            var movie = new Movie()
            {
                Id = "paw98eyrfpq4rhqr3r23rt"
            };

            db.AddRange(movie);
            await db.SaveChangesAsync();

            // Act
            var result = controller.GetAll(movie.Id);

            // Assert
            result
                .Should()
                .BeOfType<JsonResult>();
        }

        [Fact]
        public async Task GetByIdShouldReturnJson()
        {
            // Arrange
            var db = GetDatabase();

            var comment = new Comment()
            {
                Id = "paw98eyrfpq4rhqr3r23rt"
            };

            db.AddRange(comment);
            await db.SaveChangesAsync();

            var userManager = UserManagerMock.New;
            var controller = new CommentsController(new CommentsService(db), new MovieService(db), null);

            // Act
            var result = controller.GetById(comment.Id);

            // Assert
            result
                .Should()
                .BeOfType<JsonResult>();
        }

        [Fact]
        public async Task GetByIdShouldReturnNotFound()
        {
            // Arrange
            var controller = new CommentsController(new CommentsService(GetDatabase()), null, null);

            // Act
            var result = controller.GetById("Username");

            // Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }


        [Fact]
        public void DownloadCertificateShouldBeOnlyForAuthorizedUsers()
        {
            // Arrange
            var method = typeof(CommentsController)
                .GetMethod(nameof(CommentsController.Create));

            // Act
            var attributes = method.GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        private JixhDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<JixhDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new JixhDbContext(dbOptions);
        }
    }
}
