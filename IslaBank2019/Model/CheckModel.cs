using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslaBank2019.Model
{
    public class CheckModel
    {
        public string  BRSTN { get; set; }
    
        public string ChkType { get; set; }
        public string AccountNo { 
            get
        {
            if (_accountNo == null)
                    return "";
                else
                    return _accountNo;
        }
            set 
            { _accountNo = value;}
        }
        private string _accountNo;
       

        public string Name1 { get; set; }
        public string  Name2  { get; set; }
        public string Address1 { get; set; }
        public string  Address2 { get; set; }
        private string _address3;
        public string Address3
        {
            get
            {
                if (_address3 == null)
                    return "";
                else
                    return _address3;
            }
            set { _address3 = value; }
        }
        private string _address4;
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
        public int Qty { get; set; }
        public string  ChkTypeName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string  BranchName { get; set; }
        public string StartSeries { get; set; }
        public string EndSeries { get; set; }
        public string Batchfile { get; set; }
        public string ProcessBy { get; set; }

    }


}
