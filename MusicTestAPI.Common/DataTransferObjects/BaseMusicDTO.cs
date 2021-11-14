using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public class BaseMusicDTO
    {
        public User Creator { get; set; }
        public bool IsPublic { get; set; }
        public int Likes { get; set; }
    }
}
