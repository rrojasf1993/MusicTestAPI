using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Entities
{
    public class Song:BaseMusicEntity
    {
        private int _id;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        private double _duration;
        [Required]
        public double Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
    }
}
