using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public record Album
    {
        public int Id { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public User Creator { get; set; }
        public bool IsPublic { get; set; }
        public List<Song> Songs { get; set; }
    }
}
