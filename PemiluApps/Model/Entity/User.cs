using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemiluApps.Model.Entity
{
    public class User
    {
        public string UserID { get; set; }
        public string No_KTP { get; set; }
        public string Password { get; set; }
        public string TPSID { get; set; }
        public string Status { get; set; }
    }
}
