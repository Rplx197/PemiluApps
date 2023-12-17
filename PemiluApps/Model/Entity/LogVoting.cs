using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemiluApps.Model.Entity
{
    public class LogVoting
    {
        public string LogID { get; set; }
        public string Date_Log { get; set; }
        public string CandidateID { get; set; }
        public string UserID { get; set; }
        public string Place_Log { get; set; }
    }
}
