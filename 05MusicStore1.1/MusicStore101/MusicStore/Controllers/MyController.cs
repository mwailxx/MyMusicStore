using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewModels;
using MusicStoreEntity;
using System.IO;

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

            return View(myVM);
        }

        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "My") });

            var person = _context.Persons.Find(Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            //用户原来的头像
            var oldAvarda = person.Avarda;

            if(model.IsValid)
            {
                //保存头像
                if(model.Avarda!= null)
                {
                    var uploadDir = "~/Upload/Avarda";
                    //取后缀名
                    var fileLasrName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".") + 1,
                        (model.Avarda.FileName.Length - model.Avarda.FileName.LastIndexOf(".") - 1));
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID +"."+ fileLasrName);//将网站虚拟路径转化为真实的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda = "~/Upload/Avarda" + person.ID + "."+ fileLasrName;
                }

                //保存个人信息
                person.MobileNumber = model.MobiNumber;
                person.Address = model.Address;
                person.Name = model.Name;
                person.FirstName = person.Name.Substring(0, 1);
                person.LastName = person.Name.Substring(1, person.Name.Length - 1);
                person.Avarda = oldAvarda;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.AvardaUrl = oldAvarda;
            return View();
        }
    }
}