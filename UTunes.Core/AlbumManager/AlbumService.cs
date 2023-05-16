using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UTunes.Core.AlbumManager
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
        {
            this.albumRepository = albumRepository;
        }
        public async Task<OperationResult<IReadOnlyList<Album>>> GetAlbumsAsync() => (await this.albumRepository.AllAsync()).ToList();

        public OperationResult<Album> GetAlbumById(int id)
        {
            var album = this.albumRepository.GetById(id);
            if (album is null)
            {
                return new OperationResult<Album>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "Album not found"
                });
            }
            return album;
        }

        public OperationResult<Album> RateAlbum(int albumId, int rate)
        {
            var album = this.albumRepository.GetById(albumId);
            if (album is null)
            {
                return new OperationResult<Album>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "Album not found"
                });
            }
            album.Rating += rate;
            return album;
        }
    }
}
