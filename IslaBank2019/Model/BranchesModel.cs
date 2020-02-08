using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslaBank2019.Model
{
    class BranchesModel
    {
        private string returnBlankIfNull(string _input)
        {
            if (_input == null)
                return " ";
            else
                return _input;
        }

        public string BRSTN { get; set; }
        private string _address1;
        private string _address4;
        public string Address1
        {
            get
            {
                return( returnBlankIfNull(_address1));
            }
            set { _address1 = value; }
        }

        public string Address2 { get; set; }
        private string _address3;
        public string Address3
            {
                get
                {
                   return( returnBlankIfNull(_address3));
                }
                set { _address3 = value; }
            }
        public string Address4
        {
            get
            {
                if (_address4 == null)
                    return "";
                else
                    return _address4;
            }
            set { _address4 = value; }
        }
        private string _address5;
        public string Address5
        {
            get
            {
                if (_address5 == null)
                    return "";
                else
                    return _address5;
            }
            set { _address5 = value; }
        }
        private string _address6;
        public string Address6
        {
            get
            {
                if (_address6 == null)
                    return "";
                else
                    return _address6;
            }
            set { _address6 = value; }
        }
    }
}
