using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Data.Entities.Album, Common.DataTransferObjects.Album>();
            CreateMap<Data.Entities.Album, Common.DataTransferObjects.Album>().ReverseMap();
   
            CreateMap<Data.Entities.Song, Common.DataTransferObjects.Song>();
            CreateMap<Data.Entities.Song, Common.DataTransferObjects.Song>().ReverseMap();

            CreateMap<Data.Entities.Author, Common.DataTransferObjects.Author>();
            CreateMap<Data.Entities.Author, Common.DataTransferObjects.Author>().ReverseMap();
            
            CreateMap<Data.Entities.Like, Common.DataTransferObjects.Like>();
            CreateMap<Data.Entities.Like, Common.DataTransferObjects.Like>().ReverseMap();

            CreateMap<Data.Entities.User, Common.DataTransferObjects.User>();
            CreateMap<Data.Entities.User, Common.DataTransferObjects.User>().ReverseMap();
        }
    }
}
