using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Context_Services;
using Integration_Models.Master_Models;
using System.Data.Entity;
namespace Integration_Web_Application.Controllers
{
    public class FactoryController : Controller
    {
        // GET: Factory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_View()
        {
            return View();
        }
        public ActionResult SaveOrUpdate(Company_Information_Model model)
        {
            try
            {
                using (Db_Integration_Entity _db = new Db_Integration_Entity())
                {
                    m_company_information obj = new m_company_information()
                    {
                       
                        company_name=model.company_name,
                    };
                    _db.Entry(obj).State = EntityState.Added;
                    _db.SaveChanges();
                 
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}