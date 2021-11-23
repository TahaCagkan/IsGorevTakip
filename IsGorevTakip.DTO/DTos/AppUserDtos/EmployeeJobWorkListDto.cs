using IsGorevTakip.DTO.DTos.JobWorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DTO.DTos.AppUserDtos
{
    public class EmployeeJobWorkListDto
    {
        public AppUserListDto AppUser { get; set; }
       public JobWorkListDto JobWork { get; set; }
    }
}
