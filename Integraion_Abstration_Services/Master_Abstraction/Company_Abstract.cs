using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration_Interface.Master_Interface;
using Integration_Models.Master_Models;
using Data_Context_Services;
using System.Data.Entity;
namespace Integraion_Abstration_Services.Master_Abstraction
{
    public class Company_Abstract : ICompany
    {
        #region
        Db_Integration_Entity _db;
        int Server_Response;
        #endregion
        public Company_Abstract()
        {
            _db = new Db_Integration_Entity();
        }
        public int SaveOrUpdate(Company_Information_Model model)
        {
            using (Db_Integration_Entity _db = new Db_Integration_Entity())
            {
                using (var Transition = _db.Database.BeginTransaction())
                {
                    try
                    {
                        if(model.company_id==0)
                        {
                            m_company_information obj = new m_company_information()
                            {
                                ac_flag = model.ac_flag,
                                comany_bst_no = model.comany_bst_no,
                                company_address_1 = model.company_address_1,
                                company_address_2 = model.company_address_2,
                                company_city = model.company_city,
                                company_country = model.company_country,
                                company_cst = model.company_cst,
                                company_email_id = model.company_email_id,
                                company_fax_no = model.company_fax_no,
                                company_gst = model.company_gst,
                                company_name = model.company_name,
                                company_pan = model.company_pan,
                                company_phone = model.company_phone,
                                company_poster_code = model.company_poster_code,
                                company_state = model.company_state,
                                company_web_site = model.company_web_site,
                                compay_tax = model.compay_tax,
                                devloper_id = model.devloper_id
                            };
                            _db.Entry(obj).State = EntityState.Added;
                            Server_Response = 1;
                        }
                        else
                        {
                            m_company_information obj = new m_company_information()
                            {
                                company_id = model.company_id,
                                ac_flag = model.ac_flag,
                                comany_bst_no = model.comany_bst_no,
                                company_address_1 = model.company_address_1,
                                company_address_2 = model.company_address_2,
                                company_city = model.company_city,
                                company_country = model.company_country,
                                company_cst = model.company_cst,
                                company_email_id = model.company_email_id,
                                company_fax_no = model.company_fax_no,
                                company_gst = model.company_gst,
                                company_name = model.company_name,
                                company_pan = model.company_pan,
                                company_phone = model.company_phone,
                                company_poster_code = model.company_poster_code,
                                company_state = model.company_state,
                                company_web_site = model.company_web_site,
                                compay_tax = model.compay_tax,
                                devloper_id = model.devloper_id
                            };
                            _db.Entry(obj).State = EntityState.Modified;
                            Server_Response = 2;
                        }
                        _db.SaveChanges();

                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                raise = new InvalidOperationException(message, raise);
                            }
                            Transition.Rollback();
                            Server_Response = 0;
                        }

                    }
                    finally
                    {
                        Transition.Commit();
                        Transition.Dispose();
                        _db.Database.Connection.Close();
                    }
                }

            }
            return Server_Response;
        }
    }
}
