using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Context_Services;
using Integration_Models.Master_Models;
using System.Data.Entity;
using Integration_Interface.Master_Interface;
namespace Integration_Web_Application.Controllers
{
    public class CompanyController : Controller
    {
        ICompany _IComapany;
        private Company_Information_Model model;

        public Company_Information_Model Company_Information_Model { get; private set; }

        public CompanyController(ICompany init)
        {
            _IComapany = init;
        }
        // GET: Company
        public ActionResult Index()
        {
            ViewBag.State = GetState();
            ViewBag.State1 = GetCity();
            ViewBag.State2 = GetCountry();
            return View();
        }
        public ActionResult Partial_View(string v)
        {
            return View();
        }

        public ActionResult Save(Company_Information_Model model)
        {
            int Response = _IComapany.SaveOrUpdate(model);
            return RedirectToAction("Index");
        }
      
        //public List<SelectListItem>GetState()
        //{
        //    var _List = new List<SelectListItem>();
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "0",
        //       Text = "select",
        //   });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "1",
        //        Text = "Maharastra",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "2",
        //        Text = "Gujrat",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "3",
        //        Text = "Madhya Pradesh",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "4",
        //        Text = "select",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "5",
        //        Text = "Asaam",
        //    });
        //   return _List;
        //}
        public List<SelectListItem> GetState()
        {
            var get_State = new List<SelectListItem>();
            var getdata = (dynamic)null;
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                getdata = from x in _db.m_state_information
                          select new
                          {
                              x.state_id,
                              x.state_name
                          };
                foreach (var data in getdata)
                {

                    get_State.Add(new SelectListItem { Value = data.state_id.ToString(), Text = data.state_name.ToString() });
                }
            }

            return get_State;
        }
        public List<SelectListItem> GetCity()
        {
            var get_City = new List<SelectListItem>();
            var getdata = (dynamic)null;
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                getdata = from x in _db.m_city_information
                          select new
                          {
                              x.city_id,
                              x.city_name

                          };
                foreach (var data in getdata)
                {

                    get_City.Add(new SelectListItem { Value = data.city_id.ToString(), Text = data.city_name.ToString() });
                }
            }

            return get_City;
        }
        public List<SelectListItem> GetCountry()
        {
            var get_Country = new List<SelectListItem>();
            var getdata = (dynamic)null;
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                getdata = from x in _db.m_cuntry_information
                          select new
                          {
                              x.cuntry_id,
                              x.cuntry_name

                          };
                foreach (var data in getdata)
                {

                    get_Country.Add(new SelectListItem { Value = data.cuntry_id.ToString(), Text = data.cuntry_name.ToString() });
                }
            }

            return get_Country;
        }
        public ActionResult sp()
        {
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                return View(_db.Sushil().ToList());
            }
                
        }
       

        //public List<SelectListItem> GetCity()
        //{
        //    var _List = new List<SelectListItem>();
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "0",
        //        Text = "select",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "1",
        //        Text = "Dhule",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "2",
        //        Text = "Shirpur",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "3",
        //        Text = "Shindkheda",
        //    });
        //    _List.Add(new SelectListItem
        //    {
        //        Value = "4",
        //        Text = "Sakri",
        //    });

        //    return _List;
        //}
        public ActionResult Edit(int id)
        {
            ViewBag.State = GetState();
            ViewBag.State1 = GetCity();
            ViewBag.State2 = GetCountry();
            Company_Information_Model model;
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                var get_data =new m_company_information();
                get_data = _db.m_company_information.Where(m => m.company_id == id).FirstOrDefault();
                model = new Company_Information_Model()
                    {
                        company_id=get_data.company_id,
                       company_name=get_data.company_name,
                       company_address_1=get_data.company_address_1,
                       company_address_2=get_data.company_address_2,
                       company_email_id=get_data.company_email_id,
                       comany_bst_no=get_data.comany_bst_no,
                       company_state=get_data.company_state,
                       company_city=get_data.company_city,
                       company_country=get_data.company_country,
                       company_cst=get_data.company_cst,
                       company_fax_no=get_data.company_fax_no,
                       company_gst=get_data.company_gst,
                       company_pan=get_data.company_pan,
                       company_phone=get_data.company_phone,
                       company_poster_code=get_data.company_poster_code,
                       company_web_site=get_data.company_web_site,
                 };
             return PartialView("Index", model);
           }
       }
        public ActionResult Delete(int id)
        {
            ViewBag.State = GetState();
            ViewBag.State1 = GetCity();
            ViewBag.State2 = GetCountry();
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
               
                m_company_information _obj = _db.m_company_information.Find(id);
                _db.m_company_information.Remove(_obj);
                _db.SaveChanges();
                
            }
            
            return View("Index");
        }
        public ActionResult get_data(int id)
        {
            string state_name;
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                var getdat = new m_state_information();
                getdat = _db.m_state_information.Where(x => x.state_id == id).FirstOrDefault();
                state_name = getdat.state_name;
                var res = new { state_name= state_name};
                return Json(res, JsonRequestBehavior.AllowGet);


            }

               
        }
        public ActionResult get_data1(int id)
        {
            string City_name;
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                var getdata = new m_city_information();
                getdata = _db.m_city_information.Where(x => x.city_id == id).FirstOrDefault();
                City_name = getdata.city_name;
                var res = new { City_name=City_name };
                return Json(res, JsonRequestBehavior.AllowGet);
            }    
        }


    }
    
}