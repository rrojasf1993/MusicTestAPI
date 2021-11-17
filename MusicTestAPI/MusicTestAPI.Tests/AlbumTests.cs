using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicTestAPI.Common;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Services.Interfaces;
using MusicTestAPI.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicTestAPI.Tests
{
    public class AlbumTests
    {

        private AlbumController controller;
        [Fact]
        public void ReturnsOkResultWhenAreElementsInList()
        {
            //arrange
            var albumServiceMock = new Mock<IMusicItemService>();
            List<Common.DataTransferObjects.Album> albums = new List<Common.DataTransferObjects.Album>();
            OperationResult result = new OperationResult();
            Album item;
            for (int i = 0; i < 3; i++)
            {
                item = new Album();
                item.Authors = new List<Author>() { new Author() { Id = i, LastName = $"lastname{i}", Name = "name{i}" } };
                item.IsPublic = true;
                item.Name = $"album- {i}";
                albums.Add(item);
            }
            result.IsSuccesfull = true;
            result.Result = albums;
            albumServiceMock.Setup(a => a.GetAll()).Returns(result);
            controller = new AlbumController(null, albumServiceMock.Object);
            // act 
            ActionResult<IEnumerable<Album>> operationResult = controller.PublicItems();
            //assert
            var w = operationResult.Result.GetType();
            Assert.Equal(typeof(OkObjectResult), w);
        }

        [Fact]
        public void ReturnsNoContentResultWhenAreNoElementsInList()
        {
            //arrange
            var albumServiceMock = new Mock<IMusicItemService>();
            List<Common.DataTransferObjects.Album> albums = null;
            OperationResult result = new OperationResult();
            result.Result = OpCodes.NotFound;
            result.IsSuccesfull = false;
            albumServiceMock.Setup(a => a.GetAll()).Returns(result);
            controller = new AlbumController(null, albumServiceMock.Object);
            // act 
            ActionResult<IEnumerable<Album>> operationResult = controller.PublicItems();
            //assert
            var w = operationResult.Result.GetType();
            Assert.Equal(typeof(NoContentResult), w);
        }

        [Fact]
        public void ReturnsAlbumItemsWhenAreElementsInList()
        {
            //arrange
            var albumServiceMock = new Mock<IMusicItemService>();
            List<Common.DataTransferObjects.Album> albums = new List<Common.DataTransferObjects.Album>();
            OperationResult result = new OperationResult();
            Album item;
            for (int i = 0; i < 3; i++)
            {
                item = new Album();
                item.Authors = new List<Author>() { new Author() { Id = i, LastName = $"lastname{i}", Name = "name{i}" } };
                item.IsPublic = true;
                item.Name = $"album- {i}";
                albums.Add(item);
            }
            result.IsSuccesfull = true;
            result.Result = albums;
            albumServiceMock.Setup(a => a.GetAll()).Returns(result);
            controller = new AlbumController(null, albumServiceMock.Object);
            // act 
            ActionResult<IEnumerable<Album>> operationResult = controller.PublicItems();
            //assert
            var w = operationResult.Result;
            if (w is OkObjectResult)
            {
                var albumData = (IEnumerable<Album>)((OkObjectResult)w).Value;
                Assert.NotEmpty(albumData);
            }
        }
    }
}
