using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public record Song
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public double Duration { get; set; }
        public User Creator { get; set; }
        public bool IsPublic { get; set; }
    }
}
