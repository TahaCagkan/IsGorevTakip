using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Models
{
    public class EmployeeJobWorkListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public JobWorkListViewModel JobWork { get; set; }
    }
}
