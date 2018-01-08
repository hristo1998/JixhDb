namespace JixhDb.Test.Controllers
{
    using FluentAssertions;
    using JixhDb.Data;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Comments.Implementations;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    using JixhDb.Models.BindingModels.Comments;

    public class CommentsServiceTest
    {

        public CommentsServiceTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public async Task GetCommentByIdJsonShouldReturnCommentJson()
        {
            // Arrange
            var db = this.GetDatabase();

            var comment = new Comment
            {
                Id = "slihdbflisdbnfawef",
                MovieId = "lihsbdfjsndfsf",
                UserId = "s;lkdf;sldfkg"
            };

            var json = JsonConvert.SerializeObject(comment);

            db.AddRange(comment);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = commentsService.GetCommentByIdJson(comment.Id);

            // Assert
            result
                .Should()
                .Equals(json);
        }

        [Fact]
        public async Task GetCommentByIdShouldReturnComment()
        {
            // Arrange
            var db = this.GetDatabase();

            var comment = new Comment
            {
                Id = "slihdbflisdbnfawef",
                MovieId = "lihsbdfjsndfsf",
                UserId = "s;lkdf;sldfkg"
            };
            
            db.AddRange(comment);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = commentsService.GetCommentById(comment.Id);

            // Assert
            result
                .Should()
                .Be(comment);
        }

        [Fact]
        public async Task GetMovieCommentsJsonShoudReturnMovieCommentsJson()
        {
            // Arrange
            var db = this.GetDatabase();

            var comments = new List<Comment>()
            {
                new Comment
                {
                    Id = "slihdbflisdbnfawef",
                    MovieId = "lihsbsadfsdfdfjsndfsf",
                    UserId = "ssdf;lkdf;sldfkg"
                },
                new Comment
                {
                    Id = "asdfasdfasdfasdf",
                    MovieId = "dfghdfghdfghdfgh",
                    UserId = "sasd;asdfasdf;asdfasdf"
                },
                new Comment
                {
                    Id = "sdfsdfsdfhryje45yw34tawef",
                    MovieId = "w345tw34tewsrt",
                    UserId = "s;lkdf;wa34t3w4t34t34t3w4"
                },
            };

            var movie = new Movie()
            {
                Id = "asdsdfsdf",
                Title = "titanic",
                Cast = "Leo",
                StoryLine = "YEY",
                Comments = comments
            };

            var json = JsonConvert.SerializeObject(comments);

            db.AddRange(movie);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = commentsService.GetMovieCommentsJson(movie);

            // Assert
            result
                .Should()
                .Equals(json);
        }

        [Fact]
        public async Task GetMovieCommentsShoudReturnMovieComments()
        {
            // Arrange
            var db = this.GetDatabase();

            var comments = new List<Comment>()
            {
                new Comment
                {
                    Id = "slihdbflisdbnfawef",
                    MovieId = "lihsbsadfsdfdfjsndfsf",
                    UserId = "ssdf;lkdf;sldfkg"
                },
                new Comment
                {
                    Id = "asdfasdfasdfasdf",
                    MovieId = "dfghdfghdfghdfgh",
                    UserId = "sasd;asdfasdf;asdfasdf"
                },
                new Comment
                {
                    Id = "sdfsdfsdfhryje45yw34tawef",
                    MovieId = "w345tw34tewsrt",
                    UserId = "s;lkdf;wa34t3w4t34t34t3w4"
                },
            };

            var movie = new Movie()
            {
                Id = "asdsdfsdf",
                Title = "titanic",
                Cast = "Leo",
                StoryLine = "YEY",
                Comments = comments
            };

            db.AddRange(movie);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = commentsService.GetMovieComments(movie);

            // Assert
            result
                .Should()
                .Match(c => c.Any(com => com.Id == "slihdbflisdbnfawef")
                    && c.Any(com => com.Id == "asdfasdfasdfasdf")
                    && c.Any(com => com.Id == "sdfsdfsdfhryje45yw34tawef")
                    )
                    .And
                    .HaveCount(3);
        }

        [Fact]
        public async Task CreateShouldCreateComment()
        {
            // Arrange
            var db = this.GetDatabase();           

            var movie = new Movie()
            {
                Id = "asdsdfsdf",
                Title = "titanic",
                Cast = "Leo",
                StoryLine = "YEY"
            };

            var user = new User()
            {
                Id = "45ye56rtyh8q92WO3R",
                UserName = "test123",
                Email = "test@test.com"
            };

            var model = new CommentBindingModel()
            {
                Title = "I Like this movie",
                Text = "Its a great movie"
            };

            db.AddRange(movie, user);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = await commentsService.Create(user, movie, model);

            // Assert
            result.Succeeded
                .Should()
                .Be(true);

            movie.Comments
                .Should()
                .Match(r => r.Any(c => c.Title == model.Title && c.Text == model.Text));
        }

        [Fact]
        public async Task UpdateShouldUpdateComment()
        {
            // Arrange
            var db = this.GetDatabase();

            var comment = new Comment()
            {
                Title = "asdfgw56y345h",
                Text = "dfgsdfgsdfgf"
            };

            var model = new CommentBindingModel()
            {
                Title = "I Like this movie",
                Text = "Its a great movie"
            };

            db.AddRange(comment);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = await commentsService.Update(comment, model);

            // Assert
            result.Succeeded
                .Should()
                .Be(true);

            db.Comments
                .Should()
                .Match(r => r.Any(c => c.Title == model.Title && c.Text == model.Text));
        }

        [Fact]
        public async Task DeleteShouldDeleteComment()
        {
            // Arrange
            var db = this.GetDatabase();

            var comment = new Comment()
            {
                Title = "asdfgw56y345h",
                Text = "dfgsdfgsdfgf"
            };
            

            db.AddRange(comment);

            await db.SaveChangesAsync();

            var commentsService = new CommentsService(db);

            // Act
            var result = await commentsService.Delete(comment);

            // Assert
            result.Succeeded
                .Should()
                .Be(true);

            db.Comments
                .Should()
                .BeEmpty();
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
