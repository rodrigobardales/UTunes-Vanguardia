using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTunes.Api.DTOs;
using UTunes.Core;
using UTunes.Core.Entities;
using UTunes.Core.SongManager;

namespace UTunes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : UTunesBaseController
    {
        private readonly ISongService songServices;
        private readonly IMapper mapper;

        public SongsController(
            ISongService songServices,
            IMapper mapper)
        {
            this.songServices = songServices;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetSongeById(int id)
        {
            var result = this.songServices.GetSongById(id);
            var song = this.mapper.Map<SongDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(song) : GetErrorResult<Core.Entities.Song>(result);
        }
    }
}
