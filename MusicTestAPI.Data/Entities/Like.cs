using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Entities
{
    public class Like
    {
        private int _id;
[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private User _userThatLiked;
        [Required]
        public User User
        {
            get { return _userThatLiked; }
            set { _userThatLiked = value; }
        }

       


    }
}
