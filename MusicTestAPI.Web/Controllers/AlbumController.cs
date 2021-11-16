using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicTestAPI.Common;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTestAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public IMusicItemService MusicItemService { get; set; }

        private readonly ILogger<AlbumController> _logger;

        public AlbumController(IUnitOfWork uow, IMusicItemService musicItemService, ILogger<AlbumController> logger)
        {
            this.UnitOfWork = uow;
            this.MusicItemService = musicItemService;
            _logger = logger;
        }

        [HttpPost]
        [Route("create-album")]
        public ActionResult CreateAlbum(Album item) {
            {
                try
                {
                    item.IsPublic = false;
                    var operationResult = this.MusicItemService.Create(item);
                    if (operationResult.IsSuccesfull)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
                catch (Exception exc)
                {
                    return BadRequest(exc);
                }
            } }
       
        [HttpGet]
        [Route("public-albums")]
        public ActionResult<IEnumerable<Album>> PublicItems()
        {
            try
            {
                var operationResult = this.MusicItemService.GetAll();
                if(operationResult.IsSuccesfull)
                {
                    List<Album> albums = (List<Album>)operationResult.Result;
                    return Ok(albums);
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
  
        }
        [HttpGet()]
        [Route("my-albums")]
        public ActionResult<IEnumerable<Album>> MyItems(int userId)
        {
            try
            {
                var operationResult = this.MusicItemService.GetItemsByUser(userId);
                if (operationResult.IsSuccesfull)
                {
                    List<Album> albums = (List<Album>)operationResult.Result;
                    return Ok(albums);
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [HttpGet]
        [Route("my-liked-albums")]
        public ActionResult<IEnumerable<Album>> GetMyLikedAlbums(int userId)
        {
            try
            {
                var operationResult = this.MusicItemService.GetLikedItems(userId);
                if (operationResult.IsSuccesfull)
                {
                    List<Album> albums = (List<Album>)operationResult.Result;
                    return Ok(albums);
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }


        [HttpPost]
        [Route("like-album")]
        public ActionResult Like(int albumId, Like likeData)
        {
            try
            {
                var operationResult=this.MusicItemService.AddLike(albumId, likeData);
                if (operationResult.IsSuccesfull)
                {
                    return Ok();
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [HttpDelete]
        [Route("delete-album")]
        public ActionResult DeleteAlbum(int albumId, int userId)
        {
            try
            {
                var operationResult = this.MusicItemService.Delete(albumId, userId);
                if (operationResult.IsSuccesfull)
                {
                    return Ok();
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }


        [HttpDelete]
        [Route("delete-my-albums")]
        public ActionResult DeleteAllAlbums(int userId)
        {
            try
            {
                var operationResult = this.MusicItemService.DeleteAll(userId);
                if (operationResult.IsSuccesfull)
                {
                    return Ok();
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }


        [HttpPut]
        [Route("update-album")]
        public ActionResult UpdateAlbum(Album albumData)
        {
            try
            {
                var operationResult = this.MusicItemService.Update(albumData);
                if (operationResult.IsSuccesfull)
                {
                    return Ok();
                }
                else
                {
                    if ((OpCodes)operationResult.Result == OpCodes.NotFound)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(operationResult.ErrorMessage);
                    }
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }



    }
}
