using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.Concrete;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportatDal _reportatDal;
        public ReportManager(IReportatDal reportatDal)
        {
            _reportatDal = reportatDal;
        }

        public List<Report> GetAll()
        {
            return _reportatDal.GetAll();
        }

        public Report GetId(int id)
        {
            return _reportatDal.GetId(id);
        }

        public void Save(Report entity)
        {
            _reportatDal.Save(entity);
        }
        public void Delete(Report entity)
        {
            _reportatDal.Delete(entity);
        }

        public void Update(Report entity)
        {
            _reportatDal.Update(entity);
        }
    }
}
