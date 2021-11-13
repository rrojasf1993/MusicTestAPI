using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services.Interfaces
{
    interface IMusicItemService
    {
        public void Create();

        public void Update();

        public void Delete();

        public void AddLike();

        public void GetLikedItems();

    }
}
