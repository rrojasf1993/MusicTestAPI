using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public class Album:BaseMusicDTO
    {
        public int Id { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    public string Name { get; set; }
        public string Band { get; set; }
        public List<Song> Songs { get; set; }
    }
}
