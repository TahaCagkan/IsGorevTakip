using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetAllNotAdmin();
        List<AppUser> GetAllNotAdmin(out int totalPage,string searchByWord, int activePage);

    }
}
