using MinigamesBusinessLayerMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MinigamesDatabase;
using MinigamesDatabase.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace GamesApiTests
{
    public class UnitTests
    {
        //create in-memory DB for future use (not needed yet)
        //DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;
        NullLogger<Business> nullLogger = new NullLogger<Business>();

        [Fact]
        public void WhosThatPokemonPass()
        {
            // Arrange
            Business business = new Business();
            string result;

            // Act
            result = business.WhosThatPokemonGameAsync().Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RandomPokemonPass()
        {
            // Arrange
            Business business = new Business();
            string result;

            // Act
            result = business.RandomPokemonAsync().Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RpsWinNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                RpsgameStat rpsgameStat = new RpsgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(rpsgameStat);
                context.SaveChanges();
                result = business.RpsWinAsync(rpsgameStat.UserId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void RpsWinNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.RpsWinAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void RpsLostNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                RpsgameStat rpsgameStat = new RpsgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(rpsgameStat);
                context.SaveChanges();
                result = business.RpsLoseAsync(rpsgameStat.UserId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }
        [Fact]
        public void RpsLoseNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.RpsLoseAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void WtpWinNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                WtpgameStat wtpgameStat = new WtpgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(wtpgameStat);
                context.SaveChanges();
                result = business.WtpWinAsync(wtpgameStat.UserId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void WtpWinNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.WtpWinAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void WtpLoseNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                WtpgameStat wtpgameStat = new WtpgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(wtpgameStat);
                context.SaveChanges();
                result = business.WtpLoseAsync(wtpgameStat.UserId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void WtpLoseNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.WtpLoseAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void CapWinNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                CapgameStat capgameStat = new CapgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                    AverageCatchChance = 0.5
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(capgameStat);
                context.SaveChanges();
                result = business.CapWinAsync(capgameStat.UserId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void CapWinNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.CapWinAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void CapLoseNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                CapgameStat capgameStat = new CapgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                    AverageCatchChance = 0.5
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(capgameStat);
                context.SaveChanges();
                result = business.CapLoseAsync(capgameStat.UserId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void CapLoseNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.CapLoseAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is successfully updated
            }
        }

        [Fact]
        public void RpsRecordNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                RpsgameStat rpsgameStat = new RpsgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(rpsgameStat);
                context.SaveChanges();
                result = business.RpsRecordAsync(rpsgameStat.UserId).Result;

                // Assert
                Assert.NotNull(result); // result is not null if record is returned
            }
        }

        [Fact]
        public void RpsRecordNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.RpsRecordAsync(userId).Result;

                // Assert
                Assert.Null(result); // result is null if no record is returned
            }
        }

        [Fact]
        public void WtpRecordNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                WtpgameStat wtpgameStat = new WtpgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(wtpgameStat);
                context.SaveChanges();
                result = business.WtpRecordAsync(wtpgameStat.UserId).Result;

                // Assert
                Assert.NotNull(result); // result is not null if record is returned
            }
        }

        [Fact]
        public void WtpRecordNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.WtpRecordAsync(userId).Result;

                // Assert
                Assert.Null(result); // result is null if no record is returned
            }
        }

        [Fact]
        public void CapRecordNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                CapgameStat capgameStat = new CapgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    GamesWon = 1,
                    AverageCatchChance = 0.5
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(capgameStat);
                context.SaveChanges();
                result = business.CapRecordAsync(capgameStat.UserId).Result;

                // Assert
                Assert.NotNull(result); // result is not null if record is returned
            }
        }

        [Fact]
        public void CapRecordNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.CapRecordAsync(userId).Result;

                // Assert
                Assert.Null(result); // result is null if no record is returned
            }
        }

        [Fact]

        public void PhmWinPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.PhmWinAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is added
            }
        }

        [Fact]
        public void WamPlayedNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int score = 2;
                WamgameStat wamgameStat = new WamgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    HighScore = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(wamgameStat);
                context.SaveChanges();
                result = business.WamPlayedAsync(wamgameStat.UserId, score).Result;

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void PhmWinUpdatePass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.PhmWinAsync(userId).Result;
                result = business.PhmWinAsync(userId).Result; // play game twice

                // Assert
                Assert.True(result); // result is true if record is updated
            }
        }
      
        [Fact]
        public void WamPlayedNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                int score = 2;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.WamPlayedAsync(userId, score).Result;

                // Assert
                Assert.True(result); // result is true if record createed
            }
        }

        [Fact]
        public void PhmPlayedPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.PhmPlayedAsync(userId).Result;

                // Assert
                Assert.True(result); // result is true if record is added
            }
        }
        [Fact]
        public void WamHighScoreNotNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                WamgameStat wamgameStat = new WamgameStat()
                {
                    UserId = 1,
                    TotalGamesPlayed = 1,
                    HighScore = 1,
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(wamgameStat);
                context.SaveChanges();
                result = business.WamHighScoreAsync(wamgameStat.UserId).Result;

                // Assert
                Assert.NotNull(result); // result is not null if record is returned
            }
        }

        [Fact]
        public void WamHighScoreNullPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.WamHighScoreAsync(userId).Result;

                // Assert
                Assert.Null(result); // result is null if no record is returned
            }
        }

        [Fact]

        public void PhmPlayedUpdatePass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.PhmPlayedAsync(userId).Result;
                result = business.PhmPlayedAsync(userId).Result; // play game 2nd time

                // Assert
                Assert.True(result); // result is true if record is updated
            }
        }

        [Fact]
        public void GameInfoListPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                List<GameInfo> result;
                GameInfo gameInfo1 = new GameInfo()
                {
                    Description = "A cool game",
                    Title = "Cool game",
                    ImagePath = "path",
                    Route = "route"
                };
                GameInfo gameInfo2 = new GameInfo()
                {
                    Description = "A cool game 2",
                    Title = "Cool game 2",
                    ImagePath = "path 2",
                    Route = "route 2"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(gameInfo1);
                context.Add(gameInfo2);
                context.SaveChanges();
                result = business.GameInfoListAsync().Result;

                // Assert
                Assert.NotNull(result); // result is not null if list is returned
            }
        }

        [Fact]
        public void AddGameInfoPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                bool result;
                GameInfo gameInfo = new GameInfo()
                {
                    Description = "A cool game",
                    Title = "Cool game",
                    ImagePath = "path",
                    Route = "route"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.AddGameInfoAsync(gameInfo).Result;

                // Assert
                Assert.True(result); // result is true if game added
            }
        }

        [Fact]
        public void PhmRecordNotNull()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                string result = null;
                int userId = 1;
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                _ = business.PhmPlayedAsync(userId);
                _ = business.PhmWinAsync(userId);
                result = business.PhmRecordAsync(userId).Result;

                // Assert
                Assert.NotNull(result); // result is not null if record exists
            }
        }

        [Fact]
        public void CreateGamePass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                GameInfo result;
                GameDetail gameDetail = new GameDetail()
                {
                    Description = "A cool game",
                    Title = "Cool game",
                    ImageName = "Neat image",
                    Route = "route",
                    ImageSource = "source",
                    //ImageFile = ?
                    OldImageName = "Neat image's old name"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = business.CreateGameAsync(gameDetail).Result;

                // Assert
                Assert.NotNull(result); // result is not null if game created
            }
        }

        [Fact]
        public void GetGameInfoListPass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                List<GameDetail> result;
                GameInfo gameInfo1 = new GameInfo()
                {
                    Description = "A cool game",
                    Title = "Cool game",
                    ImagePath = "path",
                    Route = "route"
                };
                GameInfo gameInfo2 = new GameInfo()
                {
                    Description = "A cool game 2",
                    Title = "Cool game 2",
                    ImagePath = "path 2",
                    Route = "route 2"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(gameInfo1);
                context.Add(gameInfo2);
                context.SaveChanges();
                result = business.GetGameInfoListAsync().Result;

                // Assert
                Assert.NotNull(result); // result is not null if list returned
            }
        }

        [Fact]
        public void DeleteGamePass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                GameInfo result;
                GameInfo testInfo;
                GameDetail gameDetail = new GameDetail()
                {
                    Description = "A cool game",
                    Title = "Cool game",
                    ImageName = "Neat image",
                    Route = "route",
                    ImageSource = "source",
                    //ImageFile = ?
                    OldImageName = "Neat image's old name"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                testInfo = business.CreateGameAsync(gameDetail).Result;
                result = business.DeleteGameAsync(testInfo.Id).Result;

                // Assert
                Assert.NotNull(result); // result is not null if game deleted
            }
        }

        [Fact]
        public void ModifyGamePass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                GameInfo result;
                GameDetail gameDetail = new GameDetail()
                {
                    Id = 1,
                    Description = "A cool game",
                    Title = "Cool game",
                    ImageName = "Neat image",
                    Route = "route",
                    ImageSource = "source",
                    //ImageFile = ?
                    OldImageName = "Neat image's old name"
                };
                GameDetail gameDetailUpdated = new GameDetail()
                {
                    Id = 1,
                    Description = "A new description",
                    Title = "Cool game",
                    ImageName = "Neat image",
                    Route = "route",
                    ImageSource = "source",
                    //ImageFile = ?
                    OldImageName = "Neat image's old name"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                business.CreateGameAsync(gameDetail);
                result = business.ModifyGameAsync(gameDetailUpdated).Result;

                // Assert
                Assert.NotNull(result); // result is not null if game modified
            }
        }

        [Fact]
        public void SingleGamePass()
        {
            using (var context = new DataContext(options))
            {
                // Arrange
                GameDetail result;
                GameInfo gameInfo = new GameInfo()
                {
                    Description = "A cool game",
                    Title = "Cool game",
                    ImagePath = "path",
                    Route = "route"
                };
                Business business = new Business(context, nullLogger);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Add(gameInfo);
                context.SaveChanges();
                result = business.SingleGameAsync(gameInfo.Id).Result;

                // Assert
                Assert.NotNull(result); // result is not null 
            }
        }
    }
}
