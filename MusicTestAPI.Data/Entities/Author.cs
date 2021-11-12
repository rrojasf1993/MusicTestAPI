using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Entities
{
    public class Author
    {
        private int _id;
        [Key]
        [Required]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _lastName;
        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
    }
}
