using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public class Song:BaseMusicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
       
    }
}
