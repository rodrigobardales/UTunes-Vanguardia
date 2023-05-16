using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;

namespace UTunes.Core.AlbumManager
{
    public interface IAlbumService
    {
        Task<OperationResult<IReadOnlyList<Album>>> GetAlbumsAsync();
        OperationResult<Album> GetAlbumById(int it);
        OperationResult<Album> RateAlbum(int albumId, int rate);
    }
}
