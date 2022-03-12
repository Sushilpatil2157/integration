using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration_Models.Master_Models;
namespace Integration_Interface.Master_Interface
{
    public interface ICompany
    {
        int SaveOrUpdate(Company_Information_Model model);
    }
}
