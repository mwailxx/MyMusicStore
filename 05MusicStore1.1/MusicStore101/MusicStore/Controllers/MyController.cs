using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewModels;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // 修改个人信息ET: My
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var myVm = new MyViewModel()
            {
                Name = person.Name,
                Address = person.Address,
                MobiNumber = person.MobileNumber
            };

            ViewBag.AvardaUrl = person.Avarda;

            return View();
        }
    }
}