using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;

namespace UTunes.Core.SongManager
{
    public interface ISongService
    {
        Task<OperationResult<IReadOnlyList<Song>>> GetSongFromAlbum(int albumId);
        OperationResult<Song> GetSongById(int id);
    }
}
