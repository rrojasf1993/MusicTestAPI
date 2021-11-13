using MusicTestAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Album> Albums { get;  }
        public IRepository<Author> Authors { get;  }
        public IRepository<Song> Songs { get;  }
        public IRepository<User> Users { get;  }
        public MusicContext Context { get; set; }
        public void SaveChanges();
    }
}
