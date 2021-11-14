using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Entities
{
    public class BaseMusicEntity
    {
        private User _creator;
     
        public User Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }

        private bool _isPublic;
        [Required]
        public bool IsPublic
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }

        private List<Like> _likes;
        [Required]
        public List<Like> Likes
        {
            get { return _likes; }
            set { _likes = value; }
        }
    }
}
