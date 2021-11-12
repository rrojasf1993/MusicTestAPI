using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data.Entities
{
    public class User
    {

        private int _id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _email;
        [Required]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;
        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _firstName;
        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
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
