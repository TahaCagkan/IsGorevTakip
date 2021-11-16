using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetAllNotAdmin()
        {
            return _userDal.GetAllNotAdmin();
        }

        public List<AppUser> GetAllNotAdmin(out int totalPage,string searchByWord, int activePage)
        {
            return _userDal.GetAllNotAdmin(out totalPage,searchByWord,activePage);
        }
    }
}
