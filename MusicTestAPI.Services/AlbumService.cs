using AutoMapper;
using MusicTestAPI.Common;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public class AlbumService : BaseService
    {
        public AlbumService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            this.EntityMapper = mapper;
        }

        public override OperationResult AddLike(int itemIdToLike, Like likeData)
        {
            OperationResult result = new OperationResult();
            var albumToLike = this.UnitOfWrk.Albums.Get((a=>a.IsPublic && a.Id== itemIdToLike), includeProperties: "Songs,Authors,Creator,Likes").FirstOrDefault();
            if(albumToLike!=null)
            {
                Data.Entities.Like likeToAdd = new Data.Entities.Like();
                this.EntityMapper.Map(likeData, likeToAdd);
                likeToAdd.User = this.UnitOfWrk.Users.GetByID(likeData.User.Id);
                albumToLike.Likes.Add(likeToAdd);
                this.UnitOfWrk.Albums.Update(albumToLike);
                this.UnitOfWrk.SaveChanges();
                result.IsSuccesfull = true;
                result.Result = OpCodes.Succesfull;
            }
            else
            {
                result.IsSuccesfull = false;
                result.Result = OpCodes.NotFound;
            }
            return result;
        }

     
        public override OperationResult Create(BaseMusicDTO albumToCreate)
        {
            OperationResult result = new OperationResult();
            try
            { 
                Data.Entities.Album albumToInsert = new Data.Entities.Album();
                this.EntityMapper.Map(albumToCreate, albumToInsert);

                var creator=this.UnitOfWrk.Users.Get((c)=>c.Email==albumToInsert.Creator.Email).FirstOrDefault();
                albumToInsert.Creator = creator;

                this.UnitOfWrk.Albums.Insert(albumToInsert);
                this.UnitOfWrk.SaveChanges();
                result.IsSuccesfull = true;
                result.Result = OpCodes.Succesfull;
            }
            catch (Exception exc)
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            return result;
        }

        public override OperationResult Delete(int itemIdToDelete, int userId)
        {
            OperationResult result = new OperationResult();
            try
            {
                var albumToDelete = this.UnitOfWrk.Albums.Get((a => a.IsPublic == false && a.Id == itemIdToDelete && a.Creator.Id == userId), includeProperties: "Songs,Authors,Creator,Likes").FirstOrDefault();
                if (albumToDelete != null)
                {
                    var songsToDelete = albumToDelete.Songs;
                    if(songsToDelete.Any())
                    {
                        songsToDelete.ForEach(s => this.UnitOfWrk.Songs.Delete(s.Id));
                    }

                    var likesToDelete= albumToDelete.Likes;
                    if (likesToDelete.Any())
                    {
                        likesToDelete.ForEach(s => this.UnitOfWrk.Likes.Delete(s.Id));
                    }


                    this.UnitOfWrk.Albums.Delete(itemIdToDelete);
                    this.UnitOfWrk.SaveChanges();
                    result.IsSuccesfull = true;
                    result.Result = OpCodes.Succesfull;
                }
                else
                {
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.NotFound;
                }
            }
            catch (Exception exc)
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            return result;
        }

        public override OperationResult DeleteAll(int userId)
        {
            OperationResult result = new OperationResult();
            try
            {
                var itemsToDelete = this.UnitOfWrk.Albums.Get((a => a.IsPublic == false && a.Creator.Id == userId), includeProperties: "Songs,Authors,Creator,Likes");
                if (itemsToDelete.Any())
                {
                    foreach (var item in itemsToDelete)
                    {
                        var songsToDelete = item.Songs;
                        if (songsToDelete.Any())
                        {
                            songsToDelete.ForEach(s => this.UnitOfWrk.Songs.Delete(s.Id));
                        }

                        var likesToDelete = item.Likes;
                        if (likesToDelete.Any())
                        {
                            likesToDelete.ForEach(s => this.UnitOfWrk.Likes.Delete(s.Id));
                        }
                        this.UnitOfWrk.Albums.Delete(item);
                    }
                    this.UnitOfWrk.SaveChanges();
                    result.IsSuccesfull = true;
                    result.Result = OpCodes.Succesfull;
                }
                else
                {
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.NotFound;
                }
            }
            catch (Exception exc)
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            return result;
        }

        public override OperationResult GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                var items = this.UnitOfWrk.Albums.Get((a => a.IsPublic), includeProperties: "Songs,Authors,Creator,Likes").ToList();
                if (items.Any())
                {
                    result.Result = this.EntityMapper.Map(items, typeof(List<Data.Entities.Album>), typeof(List<Common.DataTransferObjects.Album>));
                    result.IsSuccesfull = true;
                }
                else
                {
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.NotFound;
                }
            }
            catch (Exception exc)
            
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            return result;
        }

        public override OperationResult GetItemsByUser(int userId)
        {
            OperationResult result = new OperationResult();
            try
            {
                var items = this.UnitOfWrk.Albums.Get((a => a.Creator.Id==userId ), includeProperties: "Songs,Authors,Creator,Likes").ToList();
                if (items.Any())
                {
                    result.Result = this.EntityMapper.Map(items, typeof(List<Data.Entities.Album>), typeof(List<Common.DataTransferObjects.Album>));
                    result.IsSuccesfull = true;
                }
                else
                {
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.NotFound;
                }
            }
            catch (Exception exc)
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            return result;
        }

      

        public override OperationResult GetLikedItems(int userId)
        {
            OperationResult result = new OperationResult();
            try
            {
                var items = this.UnitOfWrk.Albums.Get((a => a.Likes.Any((l)=>l.User.Id==userId)), includeProperties: "Songs,Authors,Creator,Likes").ToList();
                if (items.Any())
                {
                    result.Result = this.EntityMapper.Map(items, typeof(List<Data.Entities.Album>), typeof(List<Common.DataTransferObjects.Album>));
                    result.IsSuccesfull = true;
                }
                else
                {
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.NotFound;
                }
            }
            catch (Exception exc)
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            return result;
        }

        

        public override OperationResult Update(BaseMusicDTO itemToUpdate)
        {
            var updateData = ((Album)itemToUpdate);

            OperationResult result = new OperationResult();
            try
            {
                Data.Entities.Album albumToUpdate = new Data.Entities.Album();
                this.EntityMapper.Map(updateData, albumToUpdate);
                var album = this.UnitOfWrk.Albums.Get((a => a.IsPublic == false && a.Id == updateData.Id), includeProperties: "Songs,Authors,Creator,Likes").FirstOrDefault();
                if (album != null)
                {  
                   this.UnitOfWrk.Albums.Update(albumToUpdate);
                   this.UnitOfWrk.SaveChanges();
                }
                else
                {
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.NotFound;
                }

            }
            catch (Exception exc)
            {
                result.IsSuccesfull = false;
                result.ErrorMessages.Add($"{exc.Message}\n{exc.StackTrace}");
                result.Result = OpCodes.Error;
            }
            
            return result;
        }
    }
}
