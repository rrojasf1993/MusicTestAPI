using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public class Like
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
