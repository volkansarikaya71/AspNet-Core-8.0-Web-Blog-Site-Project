using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.Areas.Admin.ViewComponents.Chart
{
    public class ChartBox :ViewComponent
    {
        ChartManager cm = new ChartManager(new EfChartRepository());

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = cm.GetlistWhitUser(userid);
            return View(values);
        }
    }
}
