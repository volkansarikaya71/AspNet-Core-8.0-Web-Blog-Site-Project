﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace deneme3.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = nm.Getlist();
            return View(values);
        }
    }
}
