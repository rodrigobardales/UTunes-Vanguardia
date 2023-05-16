using AutoMapper;
using UTunes.Api.DTOs;
using UTunes.Core.Entities;

namespace UTunes.Api.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile() 
        {
            CreateMap<Album, AlbumDataTransferObject>();
        }
    }
}
