using UTunes.Core.Entities;

namespace UTunes.Api.DTOs
{
    public class SongDataTransferObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public int Rating { get; set; }
    }
}
