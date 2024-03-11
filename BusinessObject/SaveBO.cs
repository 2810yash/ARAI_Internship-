using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SaveBO
    {
        private int _FEEDBACKREQUESTID;
        private string _ASSESSE;
        private string _ASSESSOR;

        public string ASSESSE
        {
            get
            {
                return string.IsNullOrEmpty(_ASSESSE) ? "NULL" : _ASSESSE;
            }
            set
            {
                _ASSESSE = value;
            }
        }
        public string ASSESSOR
        {
            get
            {
                return string.IsNullOrEmpty(_ASSESSOR) ? "NULL" : _ASSESSOR;
            }
            set
            {
                _ASSESSOR = value;
            }
        }
    }
}
