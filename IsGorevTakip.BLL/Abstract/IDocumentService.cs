using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Abstract
{
    public interface IDocumentService
    {
        /// <summary>
        /// Geriye üretmiş ve upload etmiş olduğu pdf dosyasının virtual pathini döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string TransferPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// Geriye excel verisini byte dizisi olarak döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] TransferExcel<T>(List<T> list) where T : class, new();
    }
}
