using AutoMapper;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public abstract class BaseService : IMusicItemService
    {
        public IMapper EntityMapper { get ; set ; }
        public IUnitOfWork UnitOfWrk { get ; set; }

        public abstract OperationResult  AddLike(int itemIdToLike, Like likeData);
        public abstract OperationResult Create(BaseMusicDTO itemToCreate);
        public abstract OperationResult Delete(int itemIdToDelete,int userId);
        public abstract OperationResult DeleteAll(int userId);
        public abstract OperationResult GetAll();
        public abstract OperationResult GetItemsByUser(int userId);
        public abstract OperationResult GetLikedItems(int userId);
        public abstract OperationResult Update(BaseMusicDTO itemToUpdate);

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWrk = unitOfWork;
        }
    }
}
