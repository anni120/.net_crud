using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using fullcrud.Models;
using System.IO;

namespace fullcrud.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Registration R)
        {
            if (ModelState.IsValid)
            {
                string rep = Path.Combine(Server.MapPath("~/Content/Reg_img"), R.Pic.FileName);
                R.Pic.SaveAs(rep);

                string res=R.Insert_Register();
                ViewBag.msg = res;
                ModelState.Clear();

            } 
            else
            {
                Response.Write("<script>alert('please model check')</script>");
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult View_Register()
        {

            List<Registration> lst = new List<Registration>();
            lst = Registration.Select_Register();
            return View(lst);

        }
        [HttpGet]
        public ActionResult Update_Register(string up)
        {
            if (ModelState.IsValid)
            {
                Registration Re = Registration.Select_Update_Register(up);
                if (Re != null)
                {
                    return View(Re);
                }
                else
                {
                    Response.Write("<script>alert('No Record Found')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Please Model Check')</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update_Register(Registration R)
        {
            //if(ModelState.IsValid)
            //{
               string res= R.Update_Register();
               ViewBag.msg = res;
               ModelState.Clear();
            //}
            //else
            //{
            //    Response.Write("<script>alert('please model check')</script>");
            //}
            return View();
        }
        public ActionResult Delete_Register( string del,Registration R)
        {
            R.Delete_Register(del);
            //Response.Redirect("<script>alert('Record delete successfully');window.location.href='/Home/View_Register';</script>");
            Response.Write("<script>alert('Deleted')</script>");

            return View();
        }




    }
}
