using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslaBank2019.Model
{
    class RefModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string  BRSTN { get; set; }
        public string CheckType { get; set; }
        public Int64 LastNo { get; set; }
        public string BranchName { get; set; }
        public int P_Before { get; set; }
        public int C_Before { get; set; }


    }
}
