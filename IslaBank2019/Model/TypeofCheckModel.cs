using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslaBank2019.Model
{
    public class TypeofCheckModel
    {
        public List<CheckModel> PersonalCheck { get; set; }
        public List<CheckModel> CommercialCheck { get; set; }
        public List<CheckModel> ManagersCheck { get; set; }
        public List<CheckModel> ManagersContCheck { get; set; }
        public List<CheckModel> SelfRespondingCheck { get; set; }
        public List<CheckModel> TimeDepositCheck { get; set; }
    }
}
