using IsGorevTakip.Core.Enitiy.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.Entities.Concrete
{
    public class AppUser:IdentityUser<int>, IBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; } = "default.png";

        public virtual List<JobWork> JobWork { get; set; }
    }
}
