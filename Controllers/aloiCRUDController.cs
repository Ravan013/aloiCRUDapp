using aloiCRUDapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace aloiCRUDapp.Controllers
{
    public class aloiCRUDController : Controller
    {
        // GET: aloiCRUD
        aloiprojectDBEntities dbobj = new aloiprojectDBEntities();
        public ActionResult AloiCRUD(aloi_projdetails obj)
        {

            
            if (obj !=null)
            {
                return View(obj);
            }
            else
                return View(obj);


        }

        [HttpPost]


        public ActionResult Addnames(aloi_projdetails model)
        {
            if (ModelState.IsValid)
            {
                aloi_projdetails obj = new aloi_projdetails();
                obj.full_name = model.full_name;
                obj.opt_address = model.opt_address;
                obj.phone_number = model.phone_number;
                obj.fund_request = model.fund_request;
                obj.fund_amount = model.fund_amount;
                obj.fund_purpose = model.fund_purpose;
                obj.business_type = model.business_type;


                if(model.ID == 0)
                {
                    dbobj.aloi_projdetails.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;

                }

                dbobj.aloi_projdetails.Add(obj);
                dbobj.SaveChanges();

            }
            ModelState.Clear();
            return View("AloiCRUD");
            
        }


        public ActionResult NameList(string Search)
        {

            if (!String.IsNullOrEmpty(Search))
            {
                var res = dbobj.aloi_projdetails.Where(x => x.full_name.Contains(Search)).ToList();
                return View(res); 
            }
            
            else
            {
                return View(dbobj.aloi_projdetails.ToList());
            }
        }


        public ActionResult Delete(int ID)
        {
            var res = dbobj.aloi_projdetails.Where(x => x.ID == ID).First();
            dbobj.aloi_projdetails.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.aloi_projdetails.ToList();

            return View("NameList", list);
        }
    }
}