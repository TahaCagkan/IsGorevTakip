using IsGorevTakip.Core.DAL;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.Abstract
{
    public interface IAppUserDal
    {
        List<AppUser> GetAllNotAdmin();
        List<AppUser> GetAllNotAdmin(out int totalPage, string searchByWord, int activePage = 1);

    }
}
