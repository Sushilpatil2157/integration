using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Integration_Models.Master_Models
{
    public class Company_Information_Model
    {
        public int company_id { get; set; }
        [Required(ErrorMessage ="Name field is required")]
        public string company_name { get; set; }
        public string company_web_site { get; set; }
        public Nullable<int> company_country { get; set; }
        public Nullable<int> company_state { get; set; }
        public Nullable<int> company_city { get; set; }
        public string company_address_1 { get; set; }
        public string company_address_2 { get; set; }
        public string company_poster_code { get; set; }
        public string company_pan { get; set; }
        public string compay_tax { get; set; }
        public string company_gst { get; set; }
        public string company_cst { get; set; }
        public string comany_bst_no { get; set; }
        public string company_fax_no { get; set; }
        public string company_phone { get; set; }
        public string company_email_id { get; set; }
        public Nullable<int> devloper_id { get; set; }
        public string ac_flag { get; set; }
    }
}
