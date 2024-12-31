using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ChartManager : IChartService
    {
        IChartDal _chartDal;

        public ChartManager(IChartDal chartDal)
        {
            _chartDal = chartDal;
        }

        public List<Chart> Getlist()
        {
            return _chartDal.GetListAll();
        }
        public List<Chart> GetlistWhitUser(int id)
        {
            return _chartDal.GetListAll(x => x.UserId == id);
        }
        public void TAdd(Chart t)
        {
            _chartDal.Insert(t);
        }

        public void TDelete(Chart t)
        {
            _chartDal.Delete(t);
        }

        public Chart TGetById(int id)
        {
            return _chartDal.GetByID(id);
        }

        public void TUpdate(Chart t)
        {
            _chartDal.Update(t);
        }
    }
}
