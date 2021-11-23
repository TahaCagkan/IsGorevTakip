using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Abstract
{
    public interface IDeclaretionnService:IGenericService<Declarationn>
    {
        List<Declarationn> GetNotReaded(int AppUserId);

    }
}
