using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;

namespace UTunes.Core.SongManager
{
    public class SongService : ISongService
    {
        private readonly IRepository<Song> songRepository;
        
        public SongService(IRepository<Song> songRepository)
        {
            this.songRepository = songRepository;
        }

        public OperationResult<Song> GetSongById(int id)
        {
            var song = this.songRepository.GetById(id);
            if (song is null)
            {
                return new OperationResult<Song>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "The game you're trying to return doesn't exist"
                });
            }
            return song;
        }

        public async Task<OperationResult<IReadOnlyList<Song>>> GetSongFromAlbum(int albumId)
        {
            if (albumId < 0)
            {
                return (await this.songRepository.AllAsync()).ToList();
            }
            return this.songRepository.Filter(x => x.AlbumId == albumId).ToList();
        }
    }
}
