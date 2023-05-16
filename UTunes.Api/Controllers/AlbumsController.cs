using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTunes.Api.DTOs;
using UTunes.Core;
using UTunes.Core.AlbumManager;
using UTunes.Core.Entities;
using UTunes.Core.SongManager;

namespace UTunes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : UTunesBaseController
{
    private readonly IAlbumService repository;
    private readonly ISongService songsService;
    private readonly IMapper mapper;

    public AlbumsController(
        IAlbumService repository,
        ISongService songsService,
        IMapper mapper
        )
    {
        this.repository = repository;
        this.songsService = songsService;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbumsAsync()
    {
        var result = await this.repository.GetAlbumsAsync();
        var categories = this.mapper.Map<IList<AlbumDataTransferObject>>(result.Result);
        return result.Succeeded ? Ok(categories) : GetErrorResult<IReadOnlyList<Core.Entities.Album>>(result);
    }
    [HttpPut("{id}")]
    public ActionResult<AlbumDataTransferObject> RateAlbum(int albumId, [FromBody] int rate)
    {
        return Ok( );
    }

    [HttpGet("{id}")]
    public IActionResult GetAlbumById(int id)
    {
        var result = this.repository.GetAlbumById(id);
        var album = this.mapper.Map<AlbumDataTransferObject>(result.Result);
        return result.Succeeded ? Ok(album) : GetErrorResult<Core.Entities.Album>(result);
    }

    [HttpGet]
    [Route("{albumId}/songs")]
    public async Task<IActionResult> GetSongsByAlbumAsync(int albumId)
    {
        var result = await this.songsService.GetSongFromAlbum(albumId);
        var songs = this.mapper.Map<IList<SongDataTransferObject>>(result.Result);
        return result.Succeeded ? Ok(songs) : GetErrorResult<IReadOnlyList<Core.Entities.Song>>(result);


    }
}

