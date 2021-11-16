using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfAppUserRepository : EfGenericRepository<AppUser, IsGorevTakipContext>, IAppUserDal
    {
        private readonly IsGorevTakipContext context;
        public EfAppUserRepository(IsGorevTakipContext context) : base(context)
        {
            this.context = context;
        }
        public List<AppUser> GetAllNotAdmin()
        {
            //Sadece role ismi Member olan uyeler gelicek
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                 (resultUser, resultUserRole) => new
                 {
                     user = resultUser,
                     userRole = resultUserRole
                 }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                 {
                     user =resultTable.user,
                     userRoles = resultTable.userRole,
                     roles = resultRole
                 }).Where(x => x.roles.Name =="Member").Select(x => new AppUser() 
                 {
                    Id = x.user.Id,
                    Name = x.user.Name,
                    LastName = x.user.LastName,
                    Picture = x.user.Picture,
                    Email = x.user.Email,
                    UserName = x.user.UserName
                 }).ToList();          
        }

        public List<AppUser> GetAllNotAdmin(out int totalPage, string searchByWord, int activePage =1)
        {
            //Sadece role ismi Member olan uyeler gelicek
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                 (resultUser, resultUserRole) => new
                 {
                     user = resultUser,
                     userRole = resultUserRole
                 }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                 {
                     user = resultTable.user,
                     userRoles = resultTable.userRole,
                     roles = resultRole
                 }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
                 {
                     Id = x.user.Id,
                     Name = x.user.Name,
                     LastName = x.user.LastName,
                     Picture = x.user.Picture,
                     Email = x.user.Email,
                     UserName = x.user.UserName
                 });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(searchByWord))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchByWord.ToLower()) 
                || x.LastName.ToLower().Contains(searchByWord.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            }
            result =result.Skip((activePage - 1) * 4).Take(4);

            return result.ToList();
        }


        //public class ThreeModel
        //{
        //    public AppUser AppUser { get; set; }
        //    public AppRole AppRole { get; set; }

        //}
    }
}
