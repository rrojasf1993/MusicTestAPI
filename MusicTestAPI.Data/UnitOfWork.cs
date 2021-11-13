using MusicTestAPI.Data.Entities;
using MusicTestAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MusicContext _context;

        private IRepository<Album> _albums;
        public IRepository<Album> Albums { get => _albums ?? (_albums = new GenericRepository<Album>(_context)); }
        
        private IRepository<Author> _authors;
        public IRepository<Author> Authors { get => _authors ?? (_authors = new GenericRepository<Author>(_context)); }

        private IRepository<Song> _songs;
        public IRepository<Song> Songs { get => _songs ?? (_songs = new GenericRepository<Song>(_context)); }

        private IRepository<User> _users;
        public IRepository<User> Users { get => _users ?? (_users = new GenericRepository<User>(_context)); }

        private MusicContext _conntext;

        public MusicContext Context
        {
            get { return _conntext; }
            set { _conntext = value; }
        }


        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
