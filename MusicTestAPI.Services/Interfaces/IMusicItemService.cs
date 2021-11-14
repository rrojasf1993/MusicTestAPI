using AutoMapper;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services.Interfaces
{
public    interface IMusicItemService
    {
        public OperationResult Create(BaseMusicDTO itemToCreate);

        public OperationResult Update(BaseMusicDTO itemToUpdate);

        public OperationResult Delete(Int32 itemIdToDelete, int userId);

        public OperationResult DeleteAll(Int32 userId);

        public OperationResult GetAll();

        public OperationResult AddLike(int itemIdToLike, Like likeData);

        public OperationResult GetLikedItems(int userId);

        IMapper EntityMapper { get; set; }
        IUnitOfWork UnitOfWrk { get; set; }
        public void ConfigureServiceMappings();

    }
}
