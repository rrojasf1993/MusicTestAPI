using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Entities
{
    public class Album:BaseMusicEntity
    {
        private int _id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<Author> _authors;

        public List<Author> Authors
        {
            get { return _authors; }
            set { _authors = value; }
        }


        private int _year;
        [Required]
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _genre;
        [Required]
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

       
        private List<Song> _songs;

        public List<Song> Songs
        {
            get { return _songs; }
            set { _songs = value; }
        }

        private string _name;
        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _band;
        [Required]
        public string Band
        {
            get { return _band; }
            set { _band = value; }
        }


    }

}
