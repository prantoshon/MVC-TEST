using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models.CatagoryModel;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SBMSEntities DB = new SBMSEntities();
        public ActionResult Index()
        {
            return View();
        }
       //[HttpGet]
        //public ActionResult AddCatagory()
        //{
        //    return View();
        //}
        
        public ActionResult AddCatagory(Catagory model)
        {
            if (model != null)
            {
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Catagory(Catagory model)// model take data by form
        {
            if (ModelState.IsValid)
            {
                Catagory obj = new Catagory();// obj insert data in table
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Code = model.Code;

                if (model.Id == 0)// check is it already exist if not then insert
                {
                    DB.Catagories.Add(obj);
                    DB.SaveChanges();
                    ViewBag.message = "Save";
                }
                else
                {
                    DB.Entry(obj).State = EntityState.Modified; //code for update
                    DB.SaveChanges();
                    ViewBag.message = "Update";
                }


            }
            ModelState.Clear();

            return View("AddCatagory");

        }

        public ActionResult ShowCatagory()//show records 
        {
            return View(DB.Catagories.ToList());
        }

        public ActionResult DeleteCatagory(int id)
        {
            var result = DB.Catagories.Where(x => x.Id == id).First();
            DB.Catagories.Remove(result);
            DB.SaveChanges();
            var list = DB.Catagories.ToList();
            return View("ShowCatagory", list);
        }
    }
}