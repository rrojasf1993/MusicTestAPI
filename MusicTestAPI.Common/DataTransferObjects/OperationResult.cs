using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Common.DataTransferObjects
{
    public class OperationResult
    {
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private bool _isSuccesfull;

        public bool IsSuccesfull
        {
            get { return _isSuccesfull; }
            set { _isSuccesfull = value; }
        }

        private Object _result;

        public Object Result
        {
            get { return _result; }
            set { _result = value; }
        }


    }
}
