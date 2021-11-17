using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public class JwtAuthenticationResponse
    {
        private bool _isSuccesfull;

        public bool IsSuccesfull
        {
            get { return _isSuccesfull; }
            set { _isSuccesfull = value; }
        }

        private string _errorMsg;

        public string ErrorMessage
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }


    }
}
