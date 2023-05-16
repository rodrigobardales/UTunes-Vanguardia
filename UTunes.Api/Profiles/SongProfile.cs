using AutoMapper;
using UTunes.Api.DTOs;

namespace UTunes.Api.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile() 
        {
            CreateMap<Core.Entities.Song, SongDataTransferObject>();
        }
    }
}
