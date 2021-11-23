using IsGorevTakip.Core.Enitiy.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.Entities.Concrete
{
    public class Declarationn : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool  Is_Active_Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
